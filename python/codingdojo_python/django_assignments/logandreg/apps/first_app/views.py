from django.shortcuts import render, redirect
from .models import User
from django.contrib import messages

def index(request):
	return render(request, 'first_app/index.html')

def register(request):
	validation = User.objects.register(request.POST)
	if validation['status']:
		request.session['user_id'] = validation['User'].id
		return redirect('logandreg:success')

	else:
		for error in validation['errors']:
			messages.error(request, error)
			return redirect('logandreg:index')

def success(request):
	if not 'user_id' in request.session:
		messages.error(request, "Log in to continue")
		return redirect('logandreg:index')
	return render(request, 'first_app/success.html')

def login(request):
	validation = User.objects.login(request.POST)

	if validation['status']:
		request.session['user_id'] = validation['user'].id
		return redirect('logandreg:success')

	else:
		messages.error(request, validation['errors'])
		return redirect('logandreg:index')

def logout(request):
	request.session.clear()
	return redirect('logandreg:index')