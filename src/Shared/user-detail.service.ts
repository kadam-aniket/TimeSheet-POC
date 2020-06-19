import { UserDetail } from './user-detail.model';
import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserDetailService {

    formData: UserDetail;
    readonly rootUrl = 'http://localhost:51386/api';
    list : UserDetail[];

  constructor(private http : HttpClient) { }

  postUserDetail(formData: UserDetail){
     return this.http.post(this.rootUrl + '/UserDetail',formData)
  }
  deleteUserDetail(id){
     return this.http.delete(this.rootUrl + '/UserDetail/' + id);
  }

  fetchDataList(){
    this.http.get(this.rootUrl + '/UserDetail')
    .toPromise()
    .then(response => this.list = response as UserDetail[])
  }
}
