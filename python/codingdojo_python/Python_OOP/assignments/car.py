class Car(object):
	def __init__(self, price, speed, fuel, milage, tax):
		self.price = price
		self.speed = speed
		self.fuel = fuel
		self.milage = milage
		self.tax = 0

	def pricetax(self):
		if self.price > 10000:
			self.tax = .12
		else:
			self.tax = .15

	def display(self):
		print self.price
		print self.speed
		print self.fuel
		print self.milage
		print self.tax

car1 = Car(3300000, 20, "Full", "15mpg", 20)
car1.pricetax()
car1.display()

car2 = Car(2644306, 5, "Not full", "105mpg", 20)
car2.pricetax()
car2.display()

car3 = Car(400000, 15, "kind of full", "95mpg", 20)
car3.pricetax()
car3.display()

car4 = Car(1600000, 25, "Full", "25mpg", 20)
car4.pricetax()
car4.display()

car5 = Car(1600000, 45, "Empty", "25mpg", 20)
car5.pricetax()
car5.display()

car6 = Car(1600000, 35, "Empty", "15mpg", 20)
car6.pricetax()
car6.display()