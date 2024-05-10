import { Component } from '@angular/core';
import { AirportClient, GetAllAirportQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
declare var $: any;

@Component({
  selector: 'app-airport-list',
  templateUrl: './airport-list.component.html',
  styleUrls: ['./airport-list.component.css']
})
export class AirportListComponent {
  public airportDto: GetAllAirportQueryDto[] = [];

  constructor(
    private airportClient: AirportClient,
    private loader: SpinnerServiceService
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.getAirportList();

    setTimeout(function(){

      // Declare Data Table
      $('#AirportTable').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "pageLength": 10
      });

    }, 400);

  }

  getAirportList(): void {
    this.airportClient.getAllAirport().subscribe({
      next: result => {
        this.airportDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }
}
