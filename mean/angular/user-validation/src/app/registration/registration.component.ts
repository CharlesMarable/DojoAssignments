import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent 

implements OnInit {

    user = {
	  fname:"",
	  lname:"",
	  email:"",
	  password:"",
	  passwordConf:""
  }
  constructor(private _userService: UserService){}
  onSubmit(form: ngForm){
  	console.log(form);
  }

  ngOnInit() {
  }

}
