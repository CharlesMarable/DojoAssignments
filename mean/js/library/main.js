var _ = {
   map: function(array, callback) {
     for(var i = 0;i<array.length; i++){
      array[i] = callback(array[i]);
     }
   },
   reduce: function(array, callback) { 
     // code here;
   },
   find: function(array, callback) {   
     for(var i=0; i<array.length; i++){
      if(callback(array[i])){
        return array[i];
      }
     }
   },
   filter: function(array, callback) { 
     for (var i = 0;i<array.length; i++){
      if(callback(array[i])){
        return array[i];
      }
     }
   },
   reject: function(array, callback) { 
     var newarray = [];
     for(var i = 0;i<array.length; i++){
      if(!callback(array[i])){
        newarray.push(array[i]);
      }
     }
     return newarray;
   }
 }

var array = [3,4,5,6];
// _.map(array, function callback(x){return x * 5;});
// console.log(array);

// console.log(_.find(array, function callback(x){return x==3;}));

// console.log(_.filter(array, function callback(x){return x%4==0;}));

var newarray = _.reject(array, function callback(x){return x%2==0;})
console.log(newarray);

// var evens = _.filter([1, 2, 3, 4, 5, 6], function(num){ return num % 2 == 0; });
// console.log(evens); // if things are working right, this will return [2,4,6].