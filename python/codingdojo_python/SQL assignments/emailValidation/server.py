from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'mydb')

@app.route('/')
def index():
    query = "SELECT*FROM users"
    users = mysql.query_db(query)
    return render_template('index.html', all_users=users)


@app.route('/', methods=['POST'])
def create():
    query = "INSERT INTO users (email, created_at, updates_at) VALUES (:email, NOW(), NOW())"
    data = {
             'email': request.form['email'], 
           }
    mysql.query_db(query, data)
    return redirect('/')
app.run(debug=True)