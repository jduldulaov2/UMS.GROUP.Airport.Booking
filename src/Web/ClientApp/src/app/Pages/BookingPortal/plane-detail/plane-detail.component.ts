import { Component } from '@angular/core';
import { CreateAirlineCommand, PlanesClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute, Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-plane-detail',
  templateUrl: './plane-detail.component.html',
  styleUrls: ['./plane-detail.component.css']
})
export class PlaneDetailComponent {

  uniqueKey!: any;

  constructor(
    private planeClient: PlanesClient,
    private loader: SpinnerServiceService,
    private route: ActivatedRoute,
    private router: Router,
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');

    if(this.uniqueKey != null){
      this.getAirportById(this.uniqueKey);
    }
  }

  SaveAirline(inputAirlineName: any, inputCode: any, inputAirlineModel: any) {

    var errorMessage = '';

    const list = {
      airlineName: inputAirlineName,
      code: inputCode,
      model: inputAirlineModel
    };

    if(inputAirlineName == ''){
      errorMessage += "Airline is required<br>";
    }

    if(inputCode == ''){
      errorMessage += "Airline Code is required<br>";
    }

    if(inputAirlineModel == ''){
      errorMessage += "Airline Model Code is required<br>";
    }
  
    if(errorMessage == ''){
      this.planeClient.createAirline(list as CreateAirlineCommand).subscribe(
        result => {
          if(result.resultType == 1){
            this.router.navigate(['/portal/manage-planes',result.data?.id,'detail']);
          }else{
            this.DisplayErrorMessage(result.message);
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          this.DisplayErrorMessage(errors);
        }
      );
    }else{
      this.DisplayErrorMessage(errorMessage);
    }
  }

  DisplayErrorMessage(message: any){
    $("#errorMessage").html(message);
    $("#alert").show();
  }

  getAirportById(id: any): void {
    this.planeClient.getPlaneById(id).subscribe({
      next: result => {
        $("#inputAirlineName").val(result.data!.airlineName!);
        $("#inputCode").val(result.data!.code!);
        $("#inputAirlineModel").val(result.data!.model!);
        if(result.data!.isActive){
          $("#flexSwitchCheckChecked").prop('checked', true);
        }else{
          $("#flexSwitchCheckChecked").prop('checked', false);
        }
      },
      error: error => console.error(error)
    });
  }


}
