import { Component } from '@angular/core';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent {

  constructor(private loader: SpinnerServiceService){
    
  }

ngOnInit(){
    this.loader.ShowLoader();
  }

}
