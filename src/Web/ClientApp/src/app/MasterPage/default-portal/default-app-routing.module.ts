import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from '../../Pages/Auth/login/login.component';
import { DefaultPortalComponent } from '../../MasterPage/default-portal/default-portal.component';
import { HomeComponent } from '../../home/home.component';

const routes: Routes = [
  { 
    path: '', 
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class DefaultAppRoutingModule { }
