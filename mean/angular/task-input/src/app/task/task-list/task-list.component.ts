import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {

  @Input() tasks: any[];
  @Output() updateTaskList = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  update(){
    this.updateTaskList.emit();
  }
}
