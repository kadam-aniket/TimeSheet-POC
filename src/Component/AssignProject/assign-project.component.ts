import { Component, OnInit } from '@angular/core';
import { FormArray, FormGroup, FormBuilder, FormControl } from '@angular/forms'
import { of } from 'rxjs';
import { ProjectDetailService } from 'src/app/shared/project-detail.service';
import { UserDetailService } from 'src/app/shared/user-detail.service';

@Component({
  selector: 'app-assign-project',
  templateUrl: './assign-project.component.html',
  styleUrls: ['./assign-project.component.css']
})
export class AssignProjectComponent implements OnInit {
  formData: FormGroup;
  orders: [];

  constructor(public formBuilder : FormBuilder, public service1 : UserDetailService ,public service2 : ProjectDetailService) 
  {
    this.formData = this.formBuilder.group({
      orders:['']
    });

    //async orders for http service
    of(this.getOrders()).subscribe(orders=>{
        this.orders = orders;
    });
  }

  ngOnInit(): void {
    this.service1.fetchDataList();
    this.service2.fetchDataList();
  }

  getOrders(): any{
    return [
      this.service1.fetchDataList(),
      this.service2.fetchDataList()
    ]
  }
  
  onSubmit(formData: FormGroup){
    console.log(formData.value)
  }

}
