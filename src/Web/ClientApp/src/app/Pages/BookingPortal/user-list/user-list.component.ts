import { Component } from '@angular/core';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {

  constructor(private loader: SpinnerServiceService){
    
  }

  RegisterUser(){
    location.href = '/register-user';
  }

  NavigateToUser(){
    location.href = '/user-item';
  }

  ngOnInit(){
    this.loader.ShowLoader();
  }

}
