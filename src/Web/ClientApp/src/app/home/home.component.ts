import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  ngOnInit(){
    if (localStorage.getItem("credentials") !== null) {
      window.location.href = '/portal/my-dashboard';
    }
  }

}
