import { Component, OnInit } from '@angular/core';
import { ProjectDetailService } from '../shared/project-detail.service';
import { ProjectDetail } from '../shared/project-detail.model';

@Component({
  selector: 'app-project-detail-list',
  templateUrl: './project-detail-list.component.html',
  styleUrls: ['./project-detail-list.component.css']
})
export class ProjectDetailListComponent implements OnInit {

  constructor(public service : ProjectDetailService) { }

  ngOnInit(): void {
    this.service.fetchDataList();
  }

  onDelete(ProjectId){
      if(confirm('are you sure want to delete?')){
      this.service.deleteProjectDetail(ProjectId)
      .subscribe(
        response =>{
          this.service.fetchDataList();
        },
        error=>{
          console.log(error);
        }
        )
        this.service.fetchDataList();
      }
  }

  populateForm(projectdetail: ProjectDetail){
    this.service.formData = Object.assign({},projectdetail)
    console.log('Project Name is ' + projectdetail.ProjectName)
  }

}
