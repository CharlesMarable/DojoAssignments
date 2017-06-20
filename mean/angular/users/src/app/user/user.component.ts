import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

	users = [];

	Users: any[] = [
	{name:'Allen', createdAt:'5/23/17'},
	{name:'Greg', createdAt:'5/23/17'},
	{name:'David', createdAt:'5/23/17'},
	{name:'Jake', createdAt:'5/23/17'},
	]

  constructor(private _userService: UserService) {

  }

  ngOnInit() {
  	console.log(this._userService)
  	this.users = this._userService.users;
  }

}
