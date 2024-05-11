import { Component } from '@angular/core';
import { SpinnerServiceService } from '../../Services/Shared/spinner-service.service';
import { AuthClient, UsersClient } from '../../web-api-client';
declare var $: any;

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(private loader: SpinnerServiceService, private authClient: AuthClient, private userAccount: UsersClient) {}

  displayName!: any;

  ngOnInit(){
    this.DisplayLoggedInDetails();
  }

  DisplayLoggedInDetails(){
    this.authClient.geLoggedIn().subscribe({
      next: result => {
        if(result.resultType == 1){
          var loggedInId = result.data?.loggedInId;
          this.CurrentAccount(loggedInId);
        }
      },
      error: error => console.error(error)
    });
  }

  CurrentAccount(id: any){
    this.userAccount.getUserByID(id).subscribe({
      next: result => {
        if(result.resultType == 1){
          var account = result.data?.firstName + ' ' + result.data?.lastName;
          var avatar = result.data?.avatar;
          $("#DisplayName").html(account!);
          $("#DisplayAvatarName").html(avatar!);
        }
      },
      error: error => console.error(error)
    })
  }

}
