from flask import Flask, render_template, request, redirect, session
import random
app = Flask(__name__)
app.secret_key = 'Secret'

@app.route('/', methods=['POST'])
def index():
	session['numrand']=random.ranrange(0,101)
	numbox = request.form['numbox']
	return render_template('index.html')

app.run(debug=True)