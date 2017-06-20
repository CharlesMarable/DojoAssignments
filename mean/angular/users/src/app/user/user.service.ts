import { Injectable } from '@angular/core';

@Injectable()
export class UserService {

  users: any[] = [
	{name:'Allen', createdAt:'5/23/17'},
	{name:'Greg', createdAt:'5/23/17'},
	{name:'David', createdAt:'5/23/17'},
	{name:'Jake', createdAt:'5/23/17'},
	];

  constructor() { }
}
