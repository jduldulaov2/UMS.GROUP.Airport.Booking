import { Component } from '@angular/core';
import { GetAllPlanesQueryDto, PlanesClient } from '../../../web-api-client';
import { SpinnerServiceService } from '../../../Services/Shared/spinner-service.service';
declare var $: any;

@Component({
  selector: 'app-plane-list',
  templateUrl: './plane-list.component.html',
  styleUrls: ['./plane-list.component.css']
})
export class PlaneListComponent {
  
  public planeDTO: GetAllPlanesQueryDto[] = [];

  constructor(
    private planeClient: PlanesClient,
    private loader: SpinnerServiceService
  ) {
  }

  ngOnInit(){
    this.loader.ShowLoader();
    this.getPlaneList();
  }

  getPlaneList(): void {
    this.planeClient.getAllPlanes().subscribe({
      next: result => {
        this.planeDTO = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }

  onEnter(): void {
    this.GetPlaneByName();
  }

  GetPlaneByName(): void {
    this.loader.ShowLoader();
    var value = $('#txtSearch').val();
    this.planeClient.getPlaneByName(value).subscribe({
      next: result => {
        this.planeDTO = result
        console.log(result);
      },
      error: error => console.error(error)
    });
  }
  

}
