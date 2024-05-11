import { Component } from '@angular/core';
import { SpinnerServiceService } from './Services/Shared/spinner-service.service';
import { AuthClient } from './web-api-client';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  public getLoggedInQueryDto: any;

  constructor(private loader: SpinnerServiceService, private authClient: AuthClient, private router: Router, private route: ActivatedRoute) {}

  title = 'app';

  IsLoggedIn: any;

  ngOnInit(){
    this.authClient.geLoggedIn().subscribe({
      next: result => {
        if(result.message == 'Logged in user detected'){
          this.IsLoggedIn = true;
        }else{
          this.IsLoggedIn = false;
        }
      },
      error: error => console.error(error)
    });
  }
}
