from flask import Flask, render_template, request, redirect, session

app = Flask(__name__)
app.secret_key = 'Secret'

def sumSessionCounter():
  try:
    session['counter'] += 1
  except KeyError:
   		session['counter']=1

@app.route('/')
def index():
	sumSessionCounter()
	return render_template('index.html')

app.run(debug=True)