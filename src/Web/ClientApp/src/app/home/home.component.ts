import { Component } from '@angular/core';
import { SpinnerServiceService } from '../Services/Shared/spinner-service.service';
import { AuthClient } from '../web-api-client';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private loader: SpinnerServiceService, private authClient: AuthClient, private router: Router, private route: ActivatedRoute) {}

  ngOnInit(){
    this.DetectLoggedIn();
  }

  DetectLoggedIn(){
    this.authClient.geLoggedIn().subscribe({
      next: result => {
        if(result.message == 'Logged in user detected'){
          location.href = '/portal/my-dashboard';
        }
      },
      error: error => console.error(error)
    });
  }

}
