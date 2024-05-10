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

    setTimeout(function(){

      // Declare Data Table
      $('#flightTable').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "pageLength": 10
      });

    }, 1000);

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
