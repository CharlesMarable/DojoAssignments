from flask import Flask, render_template

app = Flask(__name__)

@app.route('/')

def server():
	return "this is a server"
	
app.run(debug=True)