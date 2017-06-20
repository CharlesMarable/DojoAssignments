from flask import Flask, request, redirect, render_template, session, flash
from flask_bcrypt import Bcrypt
from mysqlconnection import MySQLConnector
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9.+_-]+.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key = 'this is a key'
bcrypt = Bcrypt(app)
mysql = MySQLConnector(app,'login_reg')

@app.route('/')
def index():
	return render_template('index.html')

@app.route('/register', methods=['POST'])
def register():
	errors = []
	if len(request.form['first_name']) <2:
		errors.append('first name should be at least 2 long')

	if len(request.form['last_name']) <2:
		errors.append('last name should be at least 2 long')

	if not len(request.form['email']):
		errors.append('Enter an email please')

	if len(request.form['password']) <8:
		errors.append('password should be at least 8 long')

	if len(request.form['password_confirmation']) <8:
		errors.append('password confirmation should be at least 8 long')

	if not request.form['password'] == request.form ['password_confirmation']:
		errors.append('password fields must match')

	if not EMAIL_REGEX.match(request.form['email']):
			errors.append('enter a valid email')
	else:
		query='SELECT * FROM users WHERE email = :email'
		data = {
		'email': request.form['email']
		}
		if mysql.query_db(query, data):
			error.append('email must be unique')

	if not errors:
		hashed_password = bcrypt.generate_password_hash(request.form['password'])
		query = 'INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES (:first_name, :last_name, :email, :hashed_pw, NOW(), NOW())'
		data = {
			'first_name': request.form['first_name'],
			'last_name': request.form['last_name'],
			'email': request.form['email'],
			'hashed_pw': hashed_password,
		}
		user_id = mysql.query_db(query, data)
		session['user_id'] = user_id

		return redirect('/success')

	else:
		for error in errors:
			flash(error)
		return redirect('/')

app.run(debug=True)