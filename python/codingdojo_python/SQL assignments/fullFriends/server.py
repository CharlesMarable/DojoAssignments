from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9.+_-]+.[a-zA-Z]+$')

app = Flask(__name__)
app.secret_key = 'this is a key'
mysql = MySQLConnector(app,'mydb')

@app.route('/')
def index():
    query = 'SELECT*FROM friends'
    friends = mysql.query_db(query)
    return render_template('index.html', all_friends = friends)


@app.route('/friends/new')
def new():
	return render_template('friendsedit.html')

@app.route('/friends/create', methods = ['POST'])
def create():
	if EMAIL_REGEX.match(request.form['email']):
		query = 'INSERT INTO mydb.friends (first_name, last_name, email, created_at, updated_at) VALUES (:first_name, :last_name, :email, NOW(), NOW())'
		data = {
			'first_name': request.form['first_name'],
			'last_name': request.form['last_name'],
			'email': request.form['email']
			}
		mysql.query_db(query, data)
		return redirect('/')
	else:
		flash('Enter valid email')
		return redirect('/friends/new')

@app.route('/friends/<id>/edit')
def edit(id):
    query = 'SELECT*FROM friends WHERE id = :user_id'
    data = {
    	'user_id': id
    }
    friends = mysql.query_db(query, data)
    return render_template('edit.html', one_friend = friends[0])

@app.route('/friends/<id>/update', methods = ['POST'])
def update(id):
	query = 'UPDATE friends SET first_name = :first_name, last_name = :last_name, email = :email, updated_at = NOW() WHERE id = :user_id'
	data = {
		'user_id': id,
		'first_name': request.form['first_name'],
		'last_name': request.form['last_name'],
		'email': request.form['email']
    }
	friend = mysql.query_db(query, data)
	return redirect('/')

@app.route('/friends/<id>/show')
def show(id):
	query = 'SELECT*FROM friends WHERE id = :user_id'
	data = {
		'user_id': id
	}
	friend = mysql.query_db(query, data)
	print friend[0]
	return render_template('show.html', one_friend = friend)

@app.route('/friends/<id>/destroy', methods = ['POST'])
def delete(id):
	query = 'DELETE FROM friends WHERE id = :user_id'
	data = {
		'user_id': id
	}
	mysql.query_db(query, data)
	return redirect('/')


app.run(debug=True)
'INSERT INTO `mydb`.`friends` (`first_name`, `last_name`, `email`, `created_at`, `updated_at`) VALUES (:first_name, :last_name, :email, NOW(), NOW())'