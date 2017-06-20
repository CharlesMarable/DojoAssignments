import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrencyFormatsComponent } from './currency-formats.component';

describe('CurrencyFormatsComponent', () => {
  let component: CurrencyFormatsComponent;
  let fixture: ComponentFixture<CurrencyFormatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrencyFormatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrencyFormatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
