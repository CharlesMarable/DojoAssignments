from __future__ import unicode_literals
from django.db import models
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

class EmailManager(models.Manager):
    def validation(self, postData):
    	error = []
    	print 'in email validation'
    	print postData
    	if EMAIL_REGEX.match(postData):
    		return True
    	else:
    		return False


class Email(models.Model):
	email = models.CharField(max_length=255)
	created_at = models.DateField(auto_now_add=True)
	updated_at = models.DateField(auto_now=True)
	objects = EmailManager()