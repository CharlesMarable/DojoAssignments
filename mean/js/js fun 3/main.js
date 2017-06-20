var person = {
	name: "Allen",
	distance_traveled: 0,
	say_name: function(){
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
	},
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

function ninjaConstructor(name, cohort){
	var ninja = {},
	var belts = [yellow, red, black],
	ninja.name = name,
	ninja.cohort = cohort,
	ninja.beltlevel = 0,
	ninja.levelup: function(){
		if(ninja.belt <2){
			console.log("You have leveled up!");
			ninja.beltlevel += 1;
			ninja.belt = belts[ninja.beltlevel];
		}
		return ninja;
	}
}