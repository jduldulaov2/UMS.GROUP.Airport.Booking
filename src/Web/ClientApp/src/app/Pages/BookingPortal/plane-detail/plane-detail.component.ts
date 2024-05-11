import { Component } from '@angular/core';
import { PlanesClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-plane-detail',
  templateUrl: './plane-detail.component.html',
  styleUrls: ['./plane-detail.component.css']
})
export class PlaneDetailComponent {

  uniqueKey!: any;

  constructor(
    private planeClient: PlanesClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');
  }


}
