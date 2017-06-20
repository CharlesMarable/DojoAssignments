from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^validation$', views.validation, name='validation'),
    url(r'^success$', views.success, name='success'),
]