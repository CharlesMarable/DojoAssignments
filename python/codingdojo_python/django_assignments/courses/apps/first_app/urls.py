from django.conf.urls import url
from . import views

urlpatterns = [
	url(r'^$', views.index),
	url(r'^submit$', views.submit),
	url(r'^remove/(?P<id>\d+)', views.remove),
	url(r'^delete_this$', views.delete),
]