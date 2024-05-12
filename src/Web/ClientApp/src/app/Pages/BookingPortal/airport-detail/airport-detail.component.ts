import { Component } from '@angular/core';
import { AirportClient, CountryClient, CreateAirportCommand, GetAirportByIdQueryDto, GetAllCountryQueryDto } from '../../../web-api-client';
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
            this.router.navigate(['/portal/manage-airport',result.data?.id,'detail']);
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
