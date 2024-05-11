import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SpinnerServiceService } from '../../Services/Shared/spinner-service.service';
import { AuthClient } from '../../web-api-client';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent {

  local_url!: any;

  constructor(private loader: SpinnerServiceService, private authClient: AuthClient) {}

  SignOut(){
    this.authClient.geLoggedIn().subscribe({
      next: result => {
        if(result.resultType == 1){
          var loggedInId = result.data?.loggedInId;
          this.ProceedSignOut(loggedInId);
        }else{
          location.href = '/login';
        }
      },
      error: error => console.error(error)
    });
  }

  ProceedSignOut(id: any){
    this.authClient.logOut(id).subscribe({
      next: result => {
        if(result.resultType == 1){
          location.href = '/login';
        }
      },
      error: error => console.error(error)
    });
  }

}
