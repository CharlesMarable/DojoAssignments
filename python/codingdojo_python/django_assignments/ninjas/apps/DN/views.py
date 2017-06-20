from django.shortcuts import render

def index(request):
	return render(request, "DN/index.html")

def ninjas(request):
	context = {
		"imagesrc": "tmnt.png"
	}

	return render(request, "DN/ninjas.html", context)

def turtles(request, color):
	if color == "blue":
		context = {
		"imagesrc": "blue.png"
		}
	elif color == "purple":
		context = {
		"imagesrc": "purple.png"
		}
	elif color == "orange":
		context = {
		"imagesrc": "orange.png"
		}
	elif color == "red":
		context = {
		"imagesrc": "red.png"
		}
	else:
		context = {
		"imagesrc": "april_o'neil.png"
		}


	return render(request, "DN/ninjas.html", context)
