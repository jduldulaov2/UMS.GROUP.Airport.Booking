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

  DisplayErrorMessage(message: any){
    $("#errorMessage").html(message);
    $("#alert").show();
  }

  HideErrorMessage() {
    $("#errorMessage").html();
    $("#alert").hide();
  }
  
  ShowToast(message: any, type: any){

    $("#snackbar").html(message);
    var x = document.getElementById("snackbar");
    x!.className = "show";

    if(type == "error"){
      $("#snackbar").css("background-color","#c82333");
      $("#snackbar").css("color","white");
    }

    if(type == "success"){
      $("#snackbar").css("background-color","#20c997");
      $("#snackbar").css("color","white");
    }

    
    setTimeout(function(){ x!.className = x!.className.replace("show", ""); }, 3000);
  }

}
