from django.shortcuts import render, redirect
from django.http import HttpResponseRedirect

def index(request):
	return render(request, 'survery/index.html')

def survey(request):
	if request.method == "POST":
		print (request.POST)
		request.session['name'] = request.POST['name'],
		request.session['location'] = request.POST['location'],
		request.session['language'] = request.POST['language'],
		request.session['comment'] = request.POST['comment']
	return redirect ('survery')

def fullinfo(request):
	return render(request, 'survery/results.html')