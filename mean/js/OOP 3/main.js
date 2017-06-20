 function VehicleConstructor(name, wheels, passengers, speed){
	var distance_traveled = 0;
	var vin = function(){
		var vin = '';
		for(var i=0; i<12;i++){
			vin += (Math.floor((Math.random() * 10) + 1));
		}
		console.log(vin + " vin")
	}

	this.name = name;
	this.wheels = wheels;
	this.passengers = passengers;
	this.speed = 0;
	this.getVin = function(){
		return vin();
	}

}
VehicleConstructor.prototype.makeNoise = function(){
	console.log("beeep! beeep!");
}
VehicleConstructor.prototype.updateDistanceTravelled = function(){
	distance_traveled += speed;
	console.log(distance_traveled);
}
VehicleConstructor.prototype.move = function(){
	updateDistanceTravelled();
	this.makeNoise;
}
VehicleConstructor.prototype.checkMiles = function(){
	console.log(distance_traveled);
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
Bus.getVin();