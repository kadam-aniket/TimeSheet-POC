import { ProjectDetail } from './project-detail.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })

  export class ProjectDetailService {
    ProjectId : '';
    ProjectName : '';
    ProjectManager: '';

    formData : ProjectDetail;
    readonly rootUrl = 'http://localhost:51386/api';
    ProjectDetailslist : ProjectDetail[];
    
    constructor(public http : HttpClient) { }

    postProjectDetail(formData: ProjectDetail){
      return this.http.post(this.rootUrl + '/ProjectDetails',formData);
    }

    deleteProjectDetail(id){
      return this.http.delete(this.rootUrl + '/ProjectDetails/' + id);
    }

    fetchDataList(){
      this.http.get(this.rootUrl + '/ProjectDetails')
      .toPromise()
      .then(response=> this.ProjectDetailslist = response as ProjectDetail[]);
    }
  }

