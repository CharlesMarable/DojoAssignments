from __future__ import unicode_literals
from django.shortcuts import redirect
from django.db import models
from django.contrib import messages
import bcrypt
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

class registrationManager(models.Manager):
	def register(self, postData):
		errors = []
		if len(postData['first_name']) <2:
			errors.append('first name should be at least 2 long')

		if len(postData['last_name']) <2:
			errors.append('last name should be at least 2 long')

		if not len(postData['email']):
			errors.append('Enter an email please')

		if len(postData['password']) <8:
			errors.append('password should be at least 8 long')

		if len(postData['password_conf']) <8:
			errors.append('password confirmation should be at least 8 long')

		if not postData['password'] == postData['password_conf']:
			errors.append('password fields must match')

		if self.filter(email = postData['email']):
			errors.append('please enter a unique email')

		if not EMAIL_REGEX.match(postData['email']):
			errors.append('enter a valid email')

		validation = {}

		if not errors:
			hashed = bcrypt.hashpw(postData['password'].encode(), bcrypt.gensalt())
			user = self.create(first_name = postData['first_name'], last_name = postData['last_name'], email = postData['email'], password = hashed)
			validation['user'] = user
			validation['status'] = True

		else:
			validation['errors'] = errors
			validation['status'] = False

		return validation

	def login(self, postData):
		validation = {}
		user = self.filter(email = postData['email'])
		if not user:
			validation['status'] = False
			validation['errors'] = "Email not found"
		else:
			if bcrypt.checkpw(postData['password'].encode(), user[0].password.encode()):
				validation['status'] = True
				validation['user'] = user.first()
			else:
				validation['status'] = False
				validation['errors'] = "invalid email/password"
		return validation


class User(models.Model):
	first_name = models.CharField(max_length=45)
	last_name = models.CharField(max_length=45)
	email = models.TextField(max_length=60)
	password = models.TextField(max_length=60)
	created_at = models.DateField(auto_now_add=True)
	updated_at = models.DateField(auto_now=True)
	objects = registrationManager()
