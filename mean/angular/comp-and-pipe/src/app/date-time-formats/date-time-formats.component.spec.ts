import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DateTimeFormatsComponent } from './date-time-formats.component';

describe('DateTimeFormatsComponent', () => {
  let component: DateTimeFormatsComponent;
  let fixture: ComponentFixture<DateTimeFormatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DateTimeFormatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DateTimeFormatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
