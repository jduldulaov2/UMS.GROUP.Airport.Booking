import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  local_url!: any;

  constructor(private router: Router){
    
  }

  SignOut(){

    localStorage.removeItem("credentials");
    
    location.href = '/login';
  }
  
  NavigateToMedia(){
    location.href = '/portal/upload-media';
  }

  OnGoing(){
    alert("Page construction is still on going.");
  }

}
