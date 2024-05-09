import { Injectable } from '@angular/core';
declare var $: any;

@Injectable({
  providedIn: 'root'
})
export class SpinnerServiceService {

  constructor() { }

  ShowLoader(){
    $('#overlay').fadeIn().delay(20).fadeOut();
  }

}
