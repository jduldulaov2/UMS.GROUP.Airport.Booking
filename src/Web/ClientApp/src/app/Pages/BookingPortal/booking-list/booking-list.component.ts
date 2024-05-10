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

    setTimeout(function(){

      // Declare Data Table
      $('#BookingTable').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "pageLength": 10
      });

    }, 1000);

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

}
