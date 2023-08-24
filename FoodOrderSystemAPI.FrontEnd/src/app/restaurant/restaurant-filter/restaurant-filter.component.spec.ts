import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestaurantFilterComponent } from './restaurant-filter.component';

describe('RestaurantFilterComponent', () => {
  let component: RestaurantFilterComponent;
  let fixture: ComponentFixture<RestaurantFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantFilterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestaurantFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
