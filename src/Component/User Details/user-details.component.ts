import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserDetailService } from '../shared/user-detail.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  user = {
    username: '',
    address: ''
  };

  constructor(public service: UserDetailService) { }

  ngOnInit(): void {
  }

  onSubmit(form : NgForm){
    this.service.postUserDetail(form.value).subscribe(
      response => {
        this.service.fetchDataList();
      },
      err => {
        console.log(err)
      }
    )
      form.reset();
  }

}
