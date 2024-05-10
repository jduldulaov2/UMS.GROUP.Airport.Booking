import { Component } from '@angular/core';
import { BookingsClient, GetAllBookingQueryDto } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
declare var $: any;


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {

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
        "pageLength": 7
      });

    }, 400);

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
