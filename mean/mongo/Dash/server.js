var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var path = require('path');
var mongoose = require('mongoose');

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, './static')));
app.set('views', path.join(__dirname, './views'));
mongoose.connect('mongodb://localhost/mongoose');
app.set('view engine', 'ejs');

var MongooseSchema = new mongoose.Schema({
	name:String,
})
var mongoose = mongoose.model('mongoose', MongooseSchema);

app.get('/', function(req, res){
	mongoose.find({}, function(err, results){
		if(err){
			console.log(err);
		}
			res.render('index', { mongoose: results});
	})

})

app.get('/mongooses/add', function(req, res){
	res.render('add');
})

app.post('/add', function(req, res) {
    console.log("POST DATA", req.body);
    mongoose.create(req.body);
    res.redirect('/');
})

app.get('/mongooses/:id', function(req, res){
	mongoose.find({ _id: req.params.id}, function(err, response){
		if (err){console.log(err);}
		res.render('mongoose', { mongoose: response[0]});
	})
})

app.get('/edit/:id', function(req, res){
	mongoose.find({ _id: req.params.id }, function(err, response){
		if (err){console.log(err);}
		res.render('edit', { mongoose: response[0]});
	})
})

app.post('/edit/:id', function(req, res) {
    console.log("POST DATA", req.body);
    mongoose.update({ _id: req.params.id}, req.body, function(err, result){
    	if(err){console.log(err);}
    });
    res.redirect('/');
});

app.post('/delete/:id', function(req, res){
	mongoose.remove({ _id.: req.params.id}, function(err){
		if(err){console.log(err);}
	})
	res.redirect('/');
})

app.listen(8000, function() {
    console.log("listening on port 8000");
})