import { Component } from '@angular/core';
import { AirportClient, CountryClient, GetAllCountryQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';

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
    this.getCountryList();

    this.uniqueKey = this.route.snapshot.paramMap.get('key');

  }

  getCountryList(): void {
    this.countryClient.getCountry().subscribe({
      next: result => {
        this.countryDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
