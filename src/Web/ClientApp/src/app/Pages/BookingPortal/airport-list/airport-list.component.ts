import { Component } from '@angular/core';
import { AirportClient, GetAirportByNameQueryDto, GetAllAirportQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
declare var $: any;

@Component({
  selector: 'app-airport-list',
  templateUrl: './airport-list.component.html',
  styleUrls: ['./airport-list.component.css']
})
export class AirportListComponent {
  public airportDto: GetAllAirportQueryDto[] = [];
  public getAirportByNameQueryDto: GetAirportByNameQueryDto[] = [];
  constructor(
    private airportClient: AirportClient,
    private loader: SpinnerServiceService
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.getAirportList();
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

  onEnter(): void {
    this.GetAirportByName();
  }

  GetAirportByName(): void {
    this.loader.ShowLoader();
    var value = $('#txtSearch').val();
    this.airportClient.getAirportByName(value).subscribe({
      next: result => {
        this.airportDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
