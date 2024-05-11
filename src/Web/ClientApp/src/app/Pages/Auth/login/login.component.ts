import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { AuthClient } from '../../../web-api-client';
declare var $: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private loader: SpinnerServiceService, private authClient: AuthClient, private router: Router, private route: ActivatedRoute) {}

  txtUserName: string = "";
  txtPassword: string = "";

  ngOnInit(){
    this.DetectLoggedIn();
  }
  
  Authorize(username: string, password: string){
    this.authClient.login(username, password, false, false).subscribe({
      next: result => {
        if(result.resultType == 1){
          location.href = '/portal/my-dashboard';
        }else{
          $("#alert").show();
        }
      },
      error: error => console.error(error)
    });
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
