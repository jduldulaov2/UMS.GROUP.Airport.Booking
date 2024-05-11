import { Component } from '@angular/core';
import { FlightsClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-flight-detail',
  templateUrl: './flight-detail.component.html',
  styleUrls: ['./flight-detail.component.css']
})
export class FlightDetailComponent {

  uniqueKey!: any;

  constructor(
    private flightClient: FlightsClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');
  }

}
