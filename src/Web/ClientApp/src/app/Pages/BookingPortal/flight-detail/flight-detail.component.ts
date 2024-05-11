import { Component } from '@angular/core';
import { AirportClient, FlightsClient, GetAllAirportQueryDto, GetAllPlanesQueryDto, PlanesClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-flight-detail',
  templateUrl: './flight-detail.component.html',
  styleUrls: ['./flight-detail.component.css']
})
export class FlightDetailComponent {

  public getAllAirportQueryDto: GetAllAirportQueryDto[] = [];
  public getAllPlanesQueryDto: GetAllPlanesQueryDto[] = [];

  uniqueKey!: any;

  constructor(
    private flightClient: FlightsClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute,
    private airportClient: AirportClient,
    private airlineClient: PlanesClient
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.getAirportList();
    this.getAirlineList();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');
  }

  getAirportList(): void {
    this.airportClient.getAllAirport().subscribe({
      next: result => {
        this.getAllAirportQueryDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

  getAirlineList(): void {
    this.airlineClient.getAllPlanes().subscribe({
      next: result => {
        this.getAllPlanesQueryDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
