// We are going to create our very own constructor. Create a VehicleConstructor that takes in the name, number of wheels, and the number of passengers. Then complete the following tasks:

// Each vehicle should have a makeNoise method 
function VehicleConstructor(name, wheels, passengers){
	var vehicle = {};
	vehicle.name = name;
	vehicle.wheels = wheels;
	vehicle.passengers = passengers;
	vehicle.makeNoise = function(){
		console.log("beeep! beeep!");
	}
	return vehicle;
}


// Using the constructor, create a Bike 
// Redefine the Bike’s makeNoise method to print “ring ring!” 
var Bike = VehicleConstructor("Bike", 2, 1);
Bike.makeNoise = function(){
	console.log("ring ring!");
}

// Create a Sedan 
// Redefine the Sedan’s makeNoise method to print “Honk Honk!” 
var Sedan = VehicleConstructor("Sedan", 4, 5);
Sedan.makeNoise = function(){
	console.log("Honk Honk!");
}

// Using the constructor, create a Bus 
// Add a method to Bus that takes in the number of passengers to pick up and adds them to the passenger count​
var Bus = VehicleConstructor("Bus", 6, 0);
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
