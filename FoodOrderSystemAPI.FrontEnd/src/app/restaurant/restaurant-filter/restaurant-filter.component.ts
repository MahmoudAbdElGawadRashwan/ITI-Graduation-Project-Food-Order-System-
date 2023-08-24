import { Component, EventEmitter, Input,Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { EventData } from 'src/app/_models/eventData';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-restaurant-filter',
  templateUrl: './restaurant-filter.component.html',
  styleUrls: ['./restaurant-filter.component.css']
})
export class RestaurantFilterComponent {
  
  constructor(private productService:ProductService){}

  @Input() Categories:string[] = [];

  @Output() OnFilter:EventEmitter<EventData> = new EventEmitter<EventData>();



  boundSub:Subscription|null=null;
  BoundValues:number[] = [0,0];

  rangeValues:number[] = [0,0];


  selectedCategories:string[] = [];

  updateSlider(){
    this.rangeValues[0]=this.rangeValues[0]*this.BoundValues[1]/100;
    this.rangeValues[1]=this.rangeValues[1]*this.BoundValues[1]/100;
  }

  ngOnInit(): void {
    this.boundSub=this.productService.getPriceBounds().subscribe(
      (data) => {
        this.BoundValues = data;
      },
      (error) => {
        console.log(`error: ${error}`);
      }
    );
      
  }

  ngOnDestroy(): void {
    this.boundSub?.unsubscribe();
  }



  filter()
  {
    this.OnFilter.emit(new EventData(
      [],
      this.selectedCategories,
      this.rangeValues
    )
      );  
  }

}
