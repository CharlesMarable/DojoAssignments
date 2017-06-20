// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require body-parser (to receive post data from clients)
var bodyParser = require('body-parser');
// Integrate body-parser with our App
app.use(bodyParser.urlencoded({ extended: true }));
// Require path
var path = require('path');
var mongoose = require('mongoose');
// Setting our Static Folder Directory
app.use(express.static(path.join(__dirname, './static')));
// Setting our Views Folder Directory
app.set('views', path.join(__dirname, './views'));
mongoose.connect('mongodb://localhost/quoting');
// Setting our View Engine set to EJS
app.set('view engine', 'ejs');
var QuoteSchema = new mongoose.Schema({
	name:String,
	quote:String,
})
var Quote = mongoose.model('Quote', QuoteSchema);
// Routes
// Root Request
app.get('/', function(req, res) {
    res.render('index');
})
// Add User Request 
app.post('/quote', function(req, res) {
    console.log("POST DATA", req.body);
    Quote.create(req.body);
    res.redirect('/quotes');
})
app.get('/quotes', function(req, res){
	Quote.find({}, function(err, results){
		if(err){
			console.log(err);
		}
			res.render('quotes.ejs', { quotes: results});
	})

})
// Setting our Server to Listen on Port: 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
})