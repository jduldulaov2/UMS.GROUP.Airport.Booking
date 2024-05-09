import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  ngOnInit(){
    if (localStorage.getItem("credentials") !== null) {
      window.location.href = '/portal/my-dashboard';
    }
  }
  
  NavigateToDashboard(){

    //Temporary only
    localStorage.setItem('credentials', JSON.stringify({
      'userID': '0000-111111-222222',
      'userName': 'johndoe',
      'lastName': 'Doe',
      'firstName': 'John',
      'roleDesc' : 'Admin'
    }));

    location.href = '/portal/my-dashboard';
  }

}
