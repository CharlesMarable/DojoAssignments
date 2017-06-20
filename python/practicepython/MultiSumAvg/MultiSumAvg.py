for oddcount in range(1,1001,2):
	print oddcount

for oddcount in range(0,1000001,5):
	print oddcount

def sumoflist(list):
	sum = 0
	for i in list:
		sum = sum + i
	print sum
sumoflist([1,2,5,10,255,3])

def sumoflist(list):
	sum = 0
	for i in list:
		sum = sum + i
	avg = sum / len(list)
	print avg
sumoflist([1,2,5,10,255,3])