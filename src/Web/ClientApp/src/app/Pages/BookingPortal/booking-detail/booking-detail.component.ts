import { Component } from '@angular/core';
import { BookingsClient, FlightsClient, GetAllFlightQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-booking-detail',
  templateUrl: './booking-detail.component.html',
  styleUrls: ['./booking-detail.component.css']
})
export class BookingDetailComponent {

  public getAllFlightQueryDto: GetAllFlightQueryDto[] = [];
  uniqueKey!: any;
  DisplayName!: any;
  ContactNumber!: any;
  AvatarColor!: any;
  Avatar: any;

  constructor(
    private bookingClient: BookingsClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute,
    private flightClient: FlightsClient
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.getFlightList();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');

    if(this.uniqueKey != null){
      this.getFlightListForEdit();
    }
  }

  getFlightList(): void {
    this.flightClient.getAllFlights().subscribe({
      next: result => {
        this.getAllFlightQueryDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

  getFlightListForEdit(): void {
    this.flightClient.getAllFlights().subscribe({
      next: result => {
        this.getAllFlightQueryDto = result
        console.log(result);
        this.getBookingById(this.uniqueKey);
      },
      error: error => console.error(error)
    });
  }

  getBookingById(id: any): void {
    this.bookingClient.getBookingById(id).subscribe({
      next: result => {
        $("#inputFlight").val(result.data!.flightId!);
        $("#inputLastName").val(result.data!.lastName!);
        $("#inputFirstName").val(result.data!.firstName!);
        $("#inputMiddleName").val(result.data!.middleName!);
        $("#inputContactNumber").val(result.data!.contactNumber!);
        $("#inputStreet").val(result.data!.street!);
        $("#inputCity").val(result.data!.city!);
        $("#inputProvince").val(result.data!.province!);
        $("#inputRegion").val(result.data!.region!);
        $("#inputZipCode").val(result.data!.zipCode!);
        $("#inputFlightDate").val(result.data!.flightDate!);
        this.DisplayName = result.data!.firstName! + ' ' + result.data!.lastName!;
        this.ContactNumber = result.data!.contactNumber!;
        this.AvatarColor = result.data!.avatarColor!;
        this.Avatar = result.data!.avatar!;
      },
      error: error => console.error(error)
    });
  }

}
