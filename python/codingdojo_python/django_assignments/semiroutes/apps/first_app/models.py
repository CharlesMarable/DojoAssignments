from __future__ import unicode_literals
from django.db import models

class productManager(models.Manager):
	def new(self, postData):
		validation = {}
		errors = []
		if not len(postData['name']):
			errors.append('Must enter product name.')
		if not len(postData['description']):
			errors.append('Must enter a product description')
		if not errors:
			product = self.create(name=postData['name'], description=postData['description'], price=postData['price'])
			validation['product'] = product
			validation['status'] = True
		else:
			validation['errors'] = errors
			validation['status'] = False
		return validation


class Product(models.Model):
	name = models.CharField(max_length=255)
	description = models.TextField()
	price = models.CharField(max_length=10)
	created_at = models.DateField(auto_now_add=True)
	updated_at = models.DateField(auto_now=True)
	objects = productManager()
