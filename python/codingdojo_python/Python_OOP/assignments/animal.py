class Animal(object):
	def __init__(self, name):
		self.name = name
		self.health = 100

	def walk(self):
		self.health -= 1
		return self

	def run(self):
		self.health -=5
		return self

	def displayhealth(self):
		print self.name
		print self.health
		return self

animal1 = Animal("It")
animal1.walk().walk().walk().run().run().displayhealth()

class Dog(Animal):
	def __init__(self, name):
		super (Dog, self).__init__(name)
		self.health = 150

	def pet(self):
		self.health += 5
		return self

dog1 = Dog("bro")
dog1.walk().walk().walk().run().run().run().pet().displayhealth()

class Dragon(Animal):
	def __init__(self, name):
		super(Dragon, self).__init__(name)
		self.health = 170

	def fly(self):
		self.health - 10
		return self

	def displayhealth(self):
		super(Dragon, self).displayhealth()
		print "this is a dragon!"


dragon1 = Dragon("Chad")
dragon1.walk().walk().walk().run().run().fly().fly().displayhealth()