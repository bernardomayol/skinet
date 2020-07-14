import { Component, OnInit } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';


  constructor(private basketService: BasketService, private accountService: AccountService) {}

  ngOnInit(): void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');

      this.accountService.loadCurrentUser(token).subscribe(() => {
        console.log('loaded user.');
      }, error => {
        console.log(error);
      })

  }
  loadBasket() {
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
