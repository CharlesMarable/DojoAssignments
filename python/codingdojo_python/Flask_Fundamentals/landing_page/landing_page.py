from flask import Flask, render_template

app = Flask(__name__)

@app.route('/')
def greating():
	return render_template('index.html')

@app.route('/ninjas')
def ninjas():	
	return render_template('ninjas.html')

@app.route('/dojo/new')
def dojos():
	return render_template('dojos.html', date="3/7/17")

app.run(debug=True)