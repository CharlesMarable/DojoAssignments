//Basic: Make a function that can be used anywhere in your file and that when invoked will console.log('I am running!'); Give it the name runningLogger.
function runningLogger(){
	console.log("I am running!");
}
runningLogger();

//Basic: Make a function that is callable, has one parameter and multiplies the value of the parameter by 10 before returning the result. Give it the name multiplyByTen. Invoke it, passing it the argument 5.
function multiplyByTen(number){
	if(number < 10){
		return number * 10;
	}
}

//Basic: Write two functions (stringReturnOne and stringReturnTwo) that each return a different hard-coded string
function stringReturnOne(){
	return "yoooooooooooooooooooooooo";
}
function stringReturnTwo(){
	return "This is the move";
}

//Medium: Write a function named caller that has one parameter. If the argument provided to caller is a function (typeof may be useful), invoke the argument. Nothing is returned.
function caller(thing){
	if(typeof(thing)=='function'){
		thing();
	}
}

//Medium: Write a function named myDoubleConsoleLog that has two parameters. if the arguments passed to the function are functions, console.log the value that each function returns when invoked.
function myDoubleConsoleLog(thing1, thing2){
	if(typeof(thing1)=='function' && typeof(thing2)=='function'){
		console.log(thing1(), thing2());
	}
}

//Hard: Write a function named caller2 that has one parameter. Have it console.log the string 'starting', wait 2 seconds, and then invokes the argument if the argument is a function. (setTimeout may be useful for this one.) The function should then console.log ‘ending?’ and return “interesting”. Invoke this function by passing it myDoubleConsoleLog.
function caller2(thing3){
	console.log('starting');
	var x = setTimeout(function(){
		if(typeof(thing3)=='function'){
			thing3(stringReturnOne);
		}
	}, 2000);
	console.log('ending');
	return "interesting";
}
caller2(myDoubleConsoleLog);