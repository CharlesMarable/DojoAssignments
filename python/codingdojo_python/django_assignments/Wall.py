from django.db import models
class User(models.Model):
	first_name = models.CharFeild(max_length=50)
	last_name = models.CharFeild(max_length=50)
	email = models.EmailFeild(max_length=50)
	password = models.CharFeild(min_length=8)
	created_at = models.DateTimeFeild(auto_now_add=True)
	updated_at = models.DateTimeFeild(auto_now=True)

class Post(models.Model):
	post = models.TextFeild(max_length=1000)
	user_id = models.ForeignKey(User)
	created_at = models.DateTimeFeild(auto_now_add=True)
	updated_at = models.DateTimeFeild(auto_now=True)

class Comment(models.Model):
	comment = models.TextFeild(max_length=1000)
	post_id = models.ForeignKey(Post)
	user_id = models.ForeignKey(User)
	created_at = models.DateTimeFeild(auto_now_add=True)
	updated_at = models.DateTimeFeild(auto_now=True)