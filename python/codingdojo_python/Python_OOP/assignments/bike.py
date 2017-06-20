class Bike(object):
	def __init__(self, price, max_speed):
		self.price = price
		self.max_speed = max_speed
		self.miles = 0
	def displayinfo(self):
		print self.price
		print self.max_speed
		print self.miles
	def riding(self):
		print "Riding"
		self.miles =+ 10
	def reverse(self):
		print "Reversing"
		self.miles =- 5

bike1 = Bike(200,30)
bike1.riding().riding().riding()
bike1.riding()
bike1.riding()
bike1.reverse()
bike1.displayinfo()

bike2 = Bike(250,26)
bike2.riding()
bike2.riding()
bike2.reverse()
bike2.reverse()
bike2.displayinfo()

bike3 = Bike(230,20)
bike3.reverse()
bike3.reverse()
bike3.reverse()
bike3.displayinfo()