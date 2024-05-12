import { Component } from '@angular/core';
import { AirportClient, CreateFlightCommand, FlightsClient, GetAllAirportQueryDto, GetAllPlanesQueryDto, PlanesClient, UpdateFlightCommand } from '../../../web-api-client';
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

  UpdateFlight(inputFlightCode: any, inputAirport: any, inputAirline: any) {

    this.loader.ShowLoader();

    var errorMessage = '';

    var _isChecked = $('#flexSwitchCheckChecked').is(":checked");

    const list = {
      uniqueId: this.uniqueKey,
      flightCode: inputFlightCode,
      airportId: inputAirport,
      planeId: inputAirline,
      isActive: _isChecked
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
      this.flightClient.updateFlight(list as UpdateFlightCommand).subscribe(
        result => {
          if(result.resultType == 1){
            this.loader.ShowToast("Flight details has been successfully updated.", "success");
            this.loader.HideErrorMessage();
          }else{
            this.loader.DisplayErrorMessage(result.message);
            this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          this.loader.DisplayErrorMessage(errors);
          this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      this.loader.DisplayErrorMessage(errorMessage);
      this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
    }
  }

  CreateFlight(inputFlightCode: any, inputAirport: any, inputAirline: any) {

    this.loader.ShowLoader();
    
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
            this.loader.ShowToast("New Flight has been successfully added.", "success");
            this.router.navigate(['/portal/manage-flights',result.data?.id,'detail']);
          }else{
            this.loader.DisplayErrorMessage(result.message);
            this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          this.loader.DisplayErrorMessage(errors);
          this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      this.loader.DisplayErrorMessage(errorMessage);
      this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
    }
  }


}
