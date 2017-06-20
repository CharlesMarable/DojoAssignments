from django.shortcuts import render, redirect
import random, datetime
from django.utils import formats




def index(request):
	if 'counter' not in request.session:
		request.session['counter']=0
	if 'activities' not in request.session:
		request.session['activities']=[]
	return render(request, "gold/index.html")

def process_money(request):
	if request.method == "POST":
		now = datetime.datetime.now()
		building = request.POST['building']
		buildings = {
			'farm': random.randint(10,20),
			'cave': random.randint(2,5),
			'house': random.randint(2,10),
			'casino': random.randint(-50,50)
		}
		if building in buildings:
			gold = buildings[building]
			request.session['counter'] += gold

		formatted_datetime = formats.date_format(now, "SHORT_DATETIME_FORMAT")
		if gold < 0:
			color = 'lost'
			activity = 'You went to the {} and gained {} gold {}'.format(building.upper(), gold, formatted_datetime)

		else:
			color= 'gain'
			activity = 'You went to the {} and gained {} gold {}'.format(building.upper(), gold, formatted_datetime)

		activity = {'class': color, 'activity': activity}
		request.session['activities'].append(activity)


		# request.session['activities'].append(activity)
		print activity

		request.session.modified = True
	return redirect('/')
