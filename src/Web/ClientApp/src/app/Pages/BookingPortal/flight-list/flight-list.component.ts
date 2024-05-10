import { Component } from '@angular/core';
import { FlightsClient, GetAllFlightQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
declare var $: any;

@Component({
  selector: 'app-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.css']
})
export class FlightListComponent {

  public flightDto: GetAllFlightQueryDto[] = [];

  constructor(
    private flightClient: FlightsClient,
    private loader: SpinnerServiceService
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.getFlightList();
  }

  onEnter(): void {
    this.GetFlightByName();
  }

  GetFlightByName(): void {
    this.loader.ShowLoader();
    var value = $('#txtSearch').val();
    this.flightClient.getFlightByName(value).subscribe({
      next: result => {
        this.flightDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

  getFlightList(): void {
    this.flightClient.getAllFlights().subscribe({
      next: result => {
        this.flightDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
