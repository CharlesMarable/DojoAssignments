from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name = 'index'),
    url(r'^authors$', views.create, name = 'create'),
    url(r'^author/(?P<author_id>\d+)$', views.show, name='show'),
]
