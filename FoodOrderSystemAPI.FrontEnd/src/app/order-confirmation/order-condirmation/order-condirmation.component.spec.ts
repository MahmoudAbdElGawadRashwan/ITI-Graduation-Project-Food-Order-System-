import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderCondirmationComponent } from './order-condirmation.component';

describe('OrderCondirmationComponent', () => {
  let component: OrderCondirmationComponent;
  let fixture: ComponentFixture<OrderCondirmationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderCondirmationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderCondirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
