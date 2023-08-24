import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RestCardComponent } from './rest-card.component';

describe('RestCardComponent', () => {
  let component: RestCardComponent;
  let fixture: ComponentFixture<RestCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RestCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
