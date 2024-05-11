import { Component } from '@angular/core';
import { AirportClient, CountryClient, GetAirportByIdQueryDto, GetAllCountryQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';
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
