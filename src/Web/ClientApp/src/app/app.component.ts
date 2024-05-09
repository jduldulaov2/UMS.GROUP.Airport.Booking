import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  IsLoggedIn: any;

  ngOnInit(){

    if (localStorage.getItem("credentials") === null) {
      this.IsLoggedIn = false;
    }else{
      this.IsLoggedIn = true;
    }
  }

}
