// Go through each value in the array x, where x = [3,5,"Dojo", "rocks", "Michael", "Sensei"]. Log each value. 
	var x = [3,5,"Dojo","rocks","Michael","Sensei"];
	for(var i=0; i<x.length;i++){
		console.log(x[i]);
	}

// Add a new value (100) in the array x using a push method. 
	x.push(100);
	console.log(x);

// Add a new array ["hello", "world", "JavaScript is Fun"] to variable x. Log x in the console and analyze how x looks now. 
	x.push(["hello", "world", "JavaScript is Fun"]);
	console.log(x);

// Create a simple for loop that sums all the numbers between 1 to 500. Have console log the final sum. 
	var sum = 0;
	for(var y=1;y<=500;y++){
		sum+=y;
	}
	console.log(sum);

// Write a loop that will go through the array [1, 5, 90, 25, -3, 0], find the minimum value, and then print it 
	var arr = [1, 5, 90, 25, -3, 0];
	var min= 1000;
	for(var v = 0;v<arr.length;v++){
		if(min>arr[v]){
			min = arr[v];
		}
	}
	console.log(min);

// Write a loop that will go through the array [1, 5, 90, 25, -3, 0], find the average of all of the values, and then print it
	var sum2=0;
	var arr = [1, 5, 90, 25, -3, 0];
	for(var b=0;b<arr.length;b++){
		sum2+=arr[b];
	}
	console.log(sum2/arr.length);

// loop through object
	var newNinja = {
		name: 'Jessica',
		profession: 'coder',
		favorite_language: 'JavaScript',
		dojo: 'Dallas'
		};
	for(var val in newNinja){
		console.log(val + " " + newNinja[val])
	}
