import { Component } from '@angular/core';
import { AirportClient, CreateFlightCommand, FlightsClient, GetAllAirportQueryDto, GetAllPlanesQueryDto, PlanesClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute, Router } from '@angular/router';
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
    private airlineClient: PlanesClient,
    private router: Router
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

  CreateFlight(inputFlightCode: any, inputAirport: any, inputAirline: any) {

    var errorMessage = '';

    const list = {
      flightCode: inputFlightCode,
      airportId: inputAirport,
      planeId: inputAirline
    };

    if(inputFlightCode == ''){
      errorMessage += "Flight Code is required<br>";
    }

    if(inputAirport == '0'){
      errorMessage += "Airport is required<br>";
    }

    if(inputAirline == '0'){
      errorMessage += "Airline is required<br>";
    }
  
    if(errorMessage == ''){
      this.flightClient.createFlight(list as CreateFlightCommand).subscribe(
        result => {
          if(result.resultType == 1){
            this.router.navigate(['/portal/manage-flights',result.data?.id,'detail']);
          }else{
            this.DisplayErrorMessage(result.message);
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          this.DisplayErrorMessage(errors);
        }
      );
    }else{
      this.DisplayErrorMessage(errorMessage);
    }
  }

  DisplayErrorMessage(message: any){
    $("#errorMessage").html(message);
    $("#alert").show();
  }

}
