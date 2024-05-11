import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AdminPortalComponent } from '../../MasterPage/admin-portal/admin-portal.component';
import { BlankPageComponent } from '../../Pages/BookingPortal/blank-page/blank-page.component';
import { UserListComponent } from '../../Pages/BookingPortal/user-list/user-list.component';
import { UserDetailsComponent } from '../../Pages/BookingPortal/user-details/user-details.component';
import { UserDetailItemComponent } from '../../Pages/BookingPortal/user-detail-item/user-detail-item.component';
import { AirportListComponent } from '../../Pages/BookingPortal/airport-list/airport-list.component';
import { PlaneListComponent } from '../../Pages/BookingPortal/plane-list/plane-list.component';
import { PlaneDetailComponent } from '../../Pages/BookingPortal/plane-detail/plane-detail.component';
import { FlightListComponent } from '../../Pages/BookingPortal/flight-list/flight-list.component';
import { FlightDetailComponent } from '../../Pages/BookingPortal/flight-detail/flight-detail.component';
import { BookingListComponent } from '../../Pages/BookingPortal/booking-list/booking-list.component';
import { BookingDetailComponent } from '../../Pages/BookingPortal/booking-detail/booking-detail.component';
import { DashboardComponent } from '../../Pages/BookingPortal/dashboard/dashboard.component';
import { AirportDetailComponent } from '../../Pages/BookingPortal/airport-detail/airport-detail.component';

const routes: Routes = [
  {
    path: 'portal/my-dashboard',
    component: DashboardComponent
  },
  {
    path: 'portal/manage-airport',
    component: AirportListComponent
  },
  {
    path: 'portal/manage-airport/:key/detail',
    component: AirportDetailComponent
  },
  {
    path: 'portal/manage-airport/register',
    component: AirportDetailComponent
  },
  {
    path: 'portal/manage-planes',
    component: PlaneListComponent
  },
  {
    path: 'portal/manage-flights',
    component: FlightListComponent
  },
  {
    path: 'portal/manage-bookings',
    component: BookingListComponent
  },
  {
    path: 'portal/manage-bookings/:key/detail',
    component: BookingDetailComponent
  },
  {
    path: 'portal/manage-bookings/register-booking',
    component: BookingDetailComponent
  },
  {
    path: 'portal/manage-planes/:key/detail',
    component: PlaneDetailComponent
  },
  {
    path: 'portal/manage-flights/:key/detail',
    component: FlightDetailComponent
  },
  {
    path: 'portal/manage-planes/register-airline',
    component: PlaneDetailComponent
  },
  {
    path: 'portal/manage-flights/register-flight',
    component: FlightDetailComponent
  },
  {
    path: 'portal/blank-page',
    component: BlankPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AdminAppRoutingModule { }
