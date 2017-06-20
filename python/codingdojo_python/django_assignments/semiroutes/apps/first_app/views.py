from django.shortcuts import render, redirect
from .models import Product
from django.contrib import messages
from django.core.urlresolvers import reverse

def index(request):
	context ={
		"products":Product.objects.all()
	}
	return render(request, 'first_app/index.html', context)

def show(request, id):
	context = {
        'product' : Product.objects.get(id=id)
    }
	return render(request, 'first_app/show.html', context)

def new(request):
	return render(request, 'first_app/new.html')

def edit(request, id):
	context = {
        'product' : Product.objects.get(id=id)
    }
	return render(request, 'first_app/edit.html', context)

def create(request):
	validation = Product.objects.new(request.POST)
	if validation['status']:
		return redirect('semi:index')
	else:
		for error in validation['errors']:
			messages.error(request, error)
			return redirect('semi:new')

def update(request, id):
	if request.method=='POST':
		update = Product.objects.get(id=id)
		update.name = request.POST['name']
		update.description = request.POST['description']
		update.price = request.POST['price']
		update.save()
		return redirect('semi:index')

def destory(request, id):
	Product.objects.filter(id=id).delete()
	return redirect('semi:index')