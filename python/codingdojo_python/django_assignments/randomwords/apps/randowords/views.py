from django.shortcuts import render, redirect
import random, string

def index(request):
	return render(request, "randowords/index.html")

def generate(request):
	try:
		request.session['counter'] += 1
	except KeyError:
		request.session['counter']=1
	word=''
	letters = 'abcdefghijklmnopqrstuvwxyz'
	for i in range (0,10):
		word = word + random.choice(letters)
	words = {
		'generated_word':word
	}
	
	return render(request,"randowords/index.html", words)