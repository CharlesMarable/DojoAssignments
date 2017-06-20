from __future__ import unicode_literals
from django.db import models
from django.contrib import messages

class secretManager(models.Manager):
	def secret(self, postData):
		validation = {}
		errors = []
		pass

