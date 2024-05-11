import { Component } from '@angular/core';
import { BookingsClient, FlightsClient, GetAllFlightQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-booking-detail',
  templateUrl: './booking-detail.component.html',
  styleUrls: ['./booking-detail.component.css']
})
export class BookingDetailComponent {

  public getAllFlightQueryDto: GetAllFlightQueryDto[] = [];
  uniqueKey!: any;

  constructor(
    private bookingClient: BookingsClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute,
    private flightClient: FlightsClient
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.getFlightList();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');
  }

  getFlightList(): void {
    this.flightClient.getAllFlights().subscribe({
      next: result => {
        this.getAllFlightQueryDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
