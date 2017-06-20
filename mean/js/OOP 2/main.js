 function VehicleConstructor(name, wheels, passengers, speed){
	this.name = name;
	this.wheels = wheels;
	this.passengers = passengers;
	this.speed = 0;
	this.distance_traveled = 0;
	this.makeNoise = function(){
		console.log("beeep! beeep!");
	}
	this.updateDistanceTravelled = function(){
		distance_traveled += speed;
		console.log(distance_traveled);
	}
	this.move = function(){
		updateDistanceTravelled();
		this.makeNoise;
	}
	this.checkMiles = function(){
		console.log(distance_traveled);
	}
}

var Bike = new VehicleConstructor("Bike", 2, 1);
Bike.makeNoise = function(){
	console.log("ring ring!");
}

var Sedan = new VehicleConstructor("Sedan", 4, 5);
Sedan.makeNoise = function(){
	console.log("Honk Honk!");
}

var Bus = new VehicleConstructor("Bus", 6, 0);
Bus.addPassangers = function(count){
	if(count > 0){
		Bus.passengers += count;
	}
	else{
		Bus.passengers -= count;
	}
}
console.log(Bus.passengers);
Bus.addPassangers(2);
console.log(Bus.passengers);
Sedan.makeNoise();