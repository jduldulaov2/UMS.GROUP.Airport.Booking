import { Component } from '@angular/core';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';

@Component({
  selector: 'app-user-detail-item',
  templateUrl: './user-detail-item.component.html',
  styleUrls: ['./user-detail-item.component.css']
})
export class UserDetailItemComponent {

  constructor(private loader: SpinnerServiceService){
    
  }

  ngOnInit(){
    this.loader.ShowLoader();
  }

}
