import { Component, OnInit } from '@angular/core';
import { ProjectDetailService } from '../shared/project-detail.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-userdetails',
  templateUrl: './projectdetails.component.html',
  styleUrls: ['./projectdetails.component.css']
})
export class ProjectdetailsComponent implements OnInit {

  constructor(public service : ProjectDetailService) { }

  ngOnInit(): void {
  }

  onSubmit(form : NgForm){
    this.service.postProjectDetail(form.value).subscribe(
      response =>{
          this.service.fetchDataList();
      },
      error =>{
        console.log(error);
      }
    )
      form.reset();
  }


}
