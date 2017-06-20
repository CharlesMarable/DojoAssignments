function loopSum(x,y){
	var sum = 0;
	for(var i = x;i<y; i++){
		sum+=i;
	}
	console.log(sum);
}

function loopArray(arr){
	var min = 100;
	for(var i=0;i<arr.length;i++){
		if(min > arr[i]){
			min = arr[i];
		}
	}
	return min;
}

function loopArray2(arr){
	var sum = 0;
	for(var i=0;i<arr.length;i++){
		sum += i;
	}
	return sum/arr.length;
}

var sum = function(x,y){
	var sum = 0;
	for(var i = x;i<y; i++){
		sum+=i;
	}
	console.log(sum);
}

var min = function(arr){
	var min = 100;
	for(var i=0;i<arr.length;i++){
		if(min > arr[i]){
			min = arr[i];
		}
	}
	return min;
}

var avg = function(arr){
	var sum = 0;
	for(var i=0;i<arr.length;i++){
		sum += i;
	}
	return sum/arr.length;
}
var object = {
	sum: function(x,y){
		var sum = 0;
		for(var i = x;i<y; i++){
			sum+=i;
		}
		console.log(sum);
	},
	min: function(arr){
	var min = 100;
	for(var i=0;i<arr.length;i++){
		if(min > arr[i]){
			min = arr[i];
		}
	}
	return min;
	},
	avg: function(arr){
	var sum = 0;
	for(var i=0;i<arr.length;i++){
		sum += i;
	}
	return sum/arr.length;
	}
}
var person = {
	name: Allen,
	distance_traveled: 0,
	say_name: function(param){
		console.log(person.name);
	},
	say_something: function(param){
		if(param == "I am cool"){
			console.log(person.name + " says I'm cool")
		}
	},
	walk: function(){
		console.log(person.name + " is walking");
		person.distance_traveled += 3;
		return person;
	};
	run: function(){
		console.log(person.name + " is running");
		person.distance_traveled += 10;
		return person;
	},
	crawl: function(){
		console.log(person.name + "is crawling");
		person.distance_traveled += 1;
	}
}