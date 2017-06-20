import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DateFormatsComponent } from './date-formats.component';

describe('DateFormatsComponent', () => {
  let component: DateFormatsComponent;
  let fixture: ComponentFixture<DateFormatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DateFormatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DateFormatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
