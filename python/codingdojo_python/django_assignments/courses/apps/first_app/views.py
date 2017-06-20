from django.shortcuts import render, redirect
from .models import Course

def index(request):
	context = {
		"courses": Course.objects.all()
	}
	return render(request, "first_app/index.html", context)

def submit(request):
	if request.method == "POST":
		Course.objects.create(name = request.POST['name'], description = request.POST['description'])
	return redirect('/')

def remove(request, id):
	context = {
		"courses": Course.objects.filter(id=id)
	}
	Course.objects.filter(id=id)
	request.session['id'] = id
	print id
	return render(request, "first_app/remove.html", context)

def delete(request):
	if request.method =="POST":
		Course.objects.filter(id=request.session['id']).delete()
	return redirect('/')
