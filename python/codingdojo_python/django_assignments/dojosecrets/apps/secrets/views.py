from django.shortcuts import render
from django.contrib import messages

def index(request):
	return render(request, 'first_app/index.html')