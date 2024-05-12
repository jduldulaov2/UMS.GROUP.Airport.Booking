import { Component } from '@angular/core';
import { CreateAirlineCommand, PlanesClient, UpdateAirlineCommand } from '../../../web-api-client';
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

  UpdateAirline(inputAirlineName: any, inputCode: any, inputAirlineModel: any) {

    this.loader.ShowLoader();

    var errorMessage = '';
    var _isChecked = $('#flexSwitchCheckChecked').is(":checked");

    const list = {
      uniqueId: this.uniqueKey,
      airlineName: inputAirlineName,
      code: inputCode,
      model: inputAirlineModel,
      isActive: _isChecked
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
      this.planeClient.updateAirline(list as UpdateAirlineCommand).subscribe(
        result => {
          if(result.resultType == 1){
            this.loader.ShowToast("Plane details has been successfully updated.", "success");
            this.loader.HideErrorMessage();
          }else{
            this.loader.DisplayErrorMessage(result.message);
            this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          this.loader.DisplayErrorMessage(errors);
          this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      this.loader.DisplayErrorMessage(errorMessage);
      this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
    }
  }

  SaveAirline(inputAirlineName: any, inputCode: any, inputAirlineModel: any) {

    this.loader.ShowLoader();

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
            this.loader.ShowToast("New Plane has been successfully added.", "success");
            this.router.navigate(['/portal/manage-planes',result.data?.id,'detail']);
          }else{
            this.loader.DisplayErrorMessage(result.message);
            this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
          }
        },
        error => {
          const errors = JSON.parse(error.response).errors;
          this.loader.DisplayErrorMessage(errors);
          this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
        }
      );
    }else{
      this.loader.DisplayErrorMessage(errorMessage);
      this.loader.ShowToast("Something went wrong. Check the validation error/s.", "error");
    }
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
