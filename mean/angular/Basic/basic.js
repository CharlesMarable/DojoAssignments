var myNum: number = 5;

var myString: string = "Hello Universe";

var anythingOne: object = {any: "Hey", any: 25}

var anythingTwo: object = {any: "Hey", any: [1, 2, 3, 4]}

var anythingThree: object = {string: "Hey", object: { x: 1, y: 2 }}

// There are two ways of declaring an array type
var arrayNumbersOne: number[1, 2, 3, 4, 5, 6]; 
var arrayNumbersTwo: Array<1, 2, 3, 4, 5, 6>;

var myObj: object = { x: 5, y: 10 };

// function constructor
var MyNode = (function () {
    function MyNode(val) {
        this.val = 0;
        this.val = val;
    }
    MyNode.prototype.doSomething = function () {
        this._priv = 10;
    };
    return MyNode;
}());

var myNodeInstnace = new MyNode(1);

console.log(myNodeInstnace.val);

// This function will return nothing.
function myFunction() {
    console.log("Hello World");
}