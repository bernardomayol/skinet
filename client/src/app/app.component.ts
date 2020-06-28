import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';


  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    const baskteId = localStorage.getItem('basket_id');
    if (baskteId) {
      this.basketService.getBasket(baskteId).subscribe(() => {
        console.log('Initialized basket');
      }, error => {
        console.log(error);
      });
    }
  }

}
