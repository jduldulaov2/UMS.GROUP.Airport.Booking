import { Component } from '@angular/core';
import { AirportClient, CountryClient, CreateAirportCommand, GetAirportByIdQueryDto, GetAllCountryQueryDto, UpdateAirportCommand } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-airport-detail',
  templateUrl: './airport-detail.component.html',
  styleUrls: ['./airport-detail.component.css']
})
export class AirportDetailComponent {

  public countryDto: GetAllCountryQueryDto[] = [];

  uniqueKey!: any;

  constructor(
    private router: Router,
    private airportClient: AirportClient,
    private countryClient: CountryClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');

    if(this.uniqueKey!= null){
      this.getCountryListForEdit();
    }else{
      this.getCountryList();
    }

  }

  getCountryList(): void {
    this.countryClient.getCountry().subscribe({
      next: result => {
        this.countryDto = result
      },
      error: error => console.error(error)
    });
  }

  getCountryListForEdit(): void {
    this.countryClient.getCountry().subscribe({
      next: result => {
        this.countryDto = result;
        this.getAirportById(this.uniqueKey);
      },
      error: error => console.error(error)
    });
  }

  
  CreateAirport(inputAirport: any, inputCountry: any , inputStreet: any, inputCity: any, inputProvince: any, inputRegion: any, inputZipCode: any){

    this.loader.ShowLoader();

    var errorMessage = '';

    const list = {
      airportName: inputAirport,
      street: inputStreet,
      city: inputCity,
      province: inputProvince,
      region: inputRegion,
      zipCode: inputZipCode,
      countryId: inputCountry,
      isActive: true
    };

    if(inputAirport == ''){
      errorMessage += "Airport is required<br>";
    }

    if(inputCountry == 0){
      errorMessage += "Country is required<br>";
    }
  
    if(errorMessage == ''){
      this.airportClient.createAirport(list as CreateAirportCommand).subscribe(
        result => {
          if(result.resultType == 1){
            this.loader.ShowToast("New Airport has been successfully added.", "success");
            this.router.navigate(['/portal/manage-airport',result.data?.id,'detail']);
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

  UpdateAirport(inputAirport: any, inputCountry: any , inputStreet: any, inputCity: any, inputProvince: any, inputRegion: any, inputZipCode: any){

    this.loader.ShowLoader();
    
    var errorMessage = '';
    var _isChecked = $('#flexSwitchCheckChecked').is(":checked");

    const list = {
      uniqueId: this.uniqueKey,
      airportName: inputAirport,
      street: inputStreet,
      city: inputCity,
      province: inputProvince,
      region: inputRegion,
      zipCode: inputZipCode,
      countryId: inputCountry,
      isActive: _isChecked
    };

    if(inputAirport == ''){
      errorMessage += "Airport is required<br>";
    }

    if(inputCountry == 0){
      errorMessage += "Country is required<br>";
    }
  
    if(errorMessage == ''){
      this.airportClient.updateAirport(list as UpdateAirportCommand).subscribe(
        result => {
          if(result.resultType == 1){
            this.loader.ShowToast("Airport has been successfully updated.", "success");
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

  getAirportById(id: any): void {
    this.airportClient.getAirportById(id).subscribe({
      next: result => {
        $("#inputAirport").val(result.data!.airportName);
        $("#inputCountry").val(result.data!.countryId);
        $("#inputStreet").val(result.data!.street);
        $("#inputCity").val(result.data!.city);
        $("#inputProvince").val(result.data!.province);
        $("#inputRegion").val(result.data!.region);
        $("#inputZipCode").val(result.data!.zipCode);
        $("#AirportSummary").html(result.data!.airportName);
        $("#AirportSummaryAddress").html(result.data!.street + ' ' + result.data!.city + ' ' + result.data!.province + ', ' + result.data!.region + ' ' + result.data!.zipCode);
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
