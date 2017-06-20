# list = [5,3,6,7]
# def PrintArrayVals(list):
# 	for i in list:
# 		print i
# PrintArrayVals([5,3,6,7])

def minmaxavg(list):
	min = 0
	max = 0
	sum = 0
	for i in list:
		if i > max:
			max = i
		if i < min:
			min = i
		sum = sum + i
	avg = sum / len(list)
	print min,max,avg
minmaxavg([5,3,10,2,9,0,-2])

