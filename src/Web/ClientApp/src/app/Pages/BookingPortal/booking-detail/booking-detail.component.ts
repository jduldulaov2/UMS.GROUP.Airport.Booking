import { Component } from '@angular/core';
import { BookingsClient, CreateBookingCommand, FlightsClient, GetAllFlightQueryDto, UpdateBookingCommand } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute, Router } from '@angular/router';
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
    private flightClient: FlightsClient,
    private router: Router
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

  UpdateBooking(inputFlightId: any, inputFlightDate: any, inputLastName: any, inputFirstName: any, 
    inputMiddleName: any, inputContactNumber: any, inputStreet: any, inputCity: any, 
    inputProvince: any, inputRegion: any, inputZipCode: any): void {
      
      this.loader.ShowLoader();

   var errorMessage = '';

    const list = {
      uniqueId: this.uniqueKey,
      flightId: inputFlightId,
      flightDate: inputFlightDate,
      origin: "",
      destination: "",
      firstName: inputFirstName,
      lastName: inputLastName,
      middleName: inputMiddleName,
      street: inputStreet,
      city: inputCity,
      province: inputProvince,
      region: inputRegion,
      zipCode: inputZipCode,
      contactNumber: inputContactNumber
    };

    if(inputFlightId == '0'){
      errorMessage += "Flight # is required<br>";
    }

    if(inputFlightDate == ''){
      errorMessage += "Flight Date is required<br>";
    }

    if(inputLastName == ''){
      errorMessage += "LastName is required<br>";
    }

    if(inputFirstName == ''){
      errorMessage += "FirstName is required<br>";
    }
  
    if(errorMessage == ''){
      this.bookingClient.updateBooking(list as UpdateBookingCommand).subscribe(
        result => {
          if(result.resultType == 1){
            this.loader.ShowToast("Booking has been successfully updated.", "success");
            this.loader.HideErrorMessage();
          }else{
            this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
            this.loader.DisplayErrorMessage(result.message);
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          this.loader.DisplayErrorMessage(errors);
          this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
      this.loader.DisplayErrorMessage(errorMessage);
    }

  }

  CreateBooking(inputFlightId: any, inputFlightDate: any, inputLastName: any, inputFirstName: any, 
    inputMiddleName: any, inputContactNumber: any, inputStreet: any, inputCity: any, 
    inputProvince: any, inputRegion: any, inputZipCode: any): void {
      
    this.loader.ShowLoader();

    var errorMessage = '';

    const list = {
      flightId: inputFlightId,
      flightDate: inputFlightDate,
      origin: "",
      destination: "",
      firstName: inputFirstName,
      lastName: inputLastName,
      middleName: inputMiddleName,
      street: inputStreet,
      city: inputCity,
      province: inputProvince,
      region: inputRegion,
      zipCode: inputZipCode,
      contactNumber: inputContactNumber
    };

    if(inputFlightId == '0'){
      errorMessage += "Flight # is required<br>";
    }

    if(inputFlightDate == ''){
      errorMessage += "Flight Date is required<br>";
    }

    if(inputLastName == ''){
      errorMessage += "LastName is required<br>";
    }

    if(inputFirstName == ''){
      errorMessage += "FirstName is required<br>";
    }
  
    if(errorMessage == ''){
      this.bookingClient.createBooking(list as CreateBookingCommand).subscribe(
        result => {
          if(result.resultType == 1){
            this.loader.ShowToast("New booking has been successfully added.", "success");
            this.router.navigate(['/portal/manage-bookings',result.data?.id,'detail']);
          }else{
            this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
            this.loader.DisplayErrorMessage(result.message);
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          this.loader.DisplayErrorMessage(errors);
          this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
      this.loader.DisplayErrorMessage(errorMessage);
    }

  }

  getBookingById(id: any): void {
    this.bookingClient.getBookingById(id).subscribe({
      next: result => {
        $("#inputFlightId").val(result.data!.flightId!);
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
