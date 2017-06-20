import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-currency-formats',
  templateUrl: './currency-formats.component.html',
  styleUrls: ['./currency-formats.component.css']
})
export class CurrencyFormatsComponent implements OnInit {

  constructor() { currency: number; }

  let currency: number = 500.75;

  ngOnInit() {
  }
}
