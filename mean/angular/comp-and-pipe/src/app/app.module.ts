import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { CurrencyFormatsComponent } from './currency-formats/currency-formats.component';
import { DateFormatsComponent } from './date-formats/date-formats.component';
import { TimeComponent } from './time/time.component';
import { DateTimeFormatsComponent } from './date-time-formats/date-time-formats.component';

@NgModule({
  declarations: [
    AppComponent,
    CurrencyFormatsComponent,
    DateFormatsComponent,
    TimeComponent,
    DateTimeFormatsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
