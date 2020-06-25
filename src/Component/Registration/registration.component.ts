import { Component, OnInit } from '@angular/core';
import { RegistrationService } from '../shared/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(public service:RegistrationService ) { }

  ngOnInit(): void {
    this.service.FormModel.reset();
  }

  onSubmit(){
    this.service.register().subscribe(
      (response:any) =>{
        // if(response.succeeded){
          this.service.FormModel.reset();
       // }else{
          
        //}
      },
      error=>{
        console.log(error);
      }
    )
  }

}
