import { Component } from '@angular/core';
import { BookingsClient, GetAllBookingQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
declare var $: any;

@Component({
  selector: 'app-booking-list',
  templateUrl: './booking-list.component.html',
  styleUrls: ['./booking-list.component.css']
})
export class BookingListComponent {

  public bookingDto: GetAllBookingQueryDto[] = [];

  constructor(
    private bookingClient: BookingsClient,
    private loader: SpinnerServiceService
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.getBookingList();

  }

  getBookingList(): void {
    this.bookingClient.getAllBookings().subscribe({
      next: result => {
        this.bookingDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

  onEnter(): void {
    this.GetBookingByName();
  }

  GetBookingByName(): void {
    this.loader.ShowLoader();
    var value = $('#txtSearch').val();
    this.bookingClient.getBookingByName(value).subscribe({
      next: result => {
        this.bookingDto = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

}
