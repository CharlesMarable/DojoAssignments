from django.shortcuts import render, redirect
from django.contrib import messages
from .models import Email

def index(request):
	return render(request, 'first_app/index.html')

def validation(request):
	if Email.objects.validation(request.POST['email']):
		print request.POST['email']
		Email.objects.create(email=request.POST['email'])
		messages.success(request, 'The email address you entered is valid.')
		return redirect('/success')
	else:
		messages.error(request, 'Email is not valid!')
		return redirect('/')


def success(request):
	context = {
		'emails':Email.objects.all()
	}
	return render(request, 'first_app/success.html', context)