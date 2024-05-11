import { Component } from '@angular/core';
import { PlanesClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
import { ActivatedRoute } from '@angular/router';
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
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.uniqueKey = this.route.snapshot.paramMap.get('key');

    if(this.uniqueKey != null){
      this.getAirportById(this.uniqueKey);
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
