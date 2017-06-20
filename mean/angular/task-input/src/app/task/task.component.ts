import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent {
  tasks: any[] = [];
  constructor(private _taskService: TaskService) {
    this.getTasks();
  }
  getTasks(){
    this._taskService.getTasks()
    .toPromise()
    .then(data => this.tasks = data)
    .catch( err => err)
  }
  updateTasksParent(){
    // Service call to update our tasks
    this.getTasks();
  }
}