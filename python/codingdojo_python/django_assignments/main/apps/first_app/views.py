from django.shortcuts import render, redirect

def index(request):
	if not 'all_authors' in request.session:
		request.session['all_authors'] = []
	request.session['all_authors']
	print request.method
	return render (request, "first_app/index.html")

def create(request):
	if request.method == 'POST':
		print request.POST['author']
		authors = request.session['all_authors']
		authors.append(request.POST['author'])
		request.session['all_authors'] = authors
		print request.session['all_authors']
	return redirect('authors:index')

def show(request, author_id):
	print author_id
	return render(request, 'first_app/show.html')