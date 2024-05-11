import { Component } from '@angular/core';
import { BookingsClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-booking-detail',
  templateUrl: './booking-detail.component.html',
  styleUrls: ['./booking-detail.component.css']
})
export class BookingDetailComponent {

  uniqueKey!: any;

  constructor(
    private bookingClient: BookingsClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');
  }

}
