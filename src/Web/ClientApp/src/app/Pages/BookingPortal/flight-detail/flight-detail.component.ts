import { Component } from '@angular/core';
import { AirportClient, FlightsClient, GetAllAirportQueryDto, GetAllPlanesQueryDto, PlanesClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';
declare var $: any;

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

    if(this.uniqueKey != null){
      this.flightListInitialization();
    }
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

  flightListInitialization(): void {
    this.airportClient.getAllAirport().subscribe({
      next: result => {
        this.getAllAirportQueryDto = result
        console.log(result);
        this.airlineClient.getAllPlanes().subscribe({
          next: _result => {
            this.getAllPlanesQueryDto = _result
            console.log(_result);
            this.getFlightById(this.uniqueKey);
          },
          error: error => console.error(error)
        });

      },
      error: error => console.error(error)
    });
  }

  getFlightById(id: any): void {
    this.flightClient.getFlightById(id).subscribe({
      next: result => {
        $("#inputFlightCode").val(result.data!.flightCode!);
        $("#inputAirport").val(result.data!.airportId!);
        $("#inputAirline").val(result.data!.planeId!);
        if(result.data!.isActive){
          $("#flexSwitchCheckChecked").prop('checked', true);
        }else{
          $("#flexSwitchCheckChecked").prop('checked', false);
        }
      },
      error: error => console.error(error)
    });
  }

}
