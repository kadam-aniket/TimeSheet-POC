import { Component, OnInit } from '@angular/core';
import { UserDetailService } from '../shared/user-detail.service';
import { UserDetail } from '../shared/user-detail.model';

@Component({
  selector: 'app-user-detail-list',
  templateUrl: './user-detail-list.component.html',
  styleUrls: ['./user-detail-list.component.css']
})
export class UserDetailListComponent implements OnInit {

  constructor(public service : UserDetailService) { }

  ngOnInit(): void {
    this.service.fetchDataList();
  }

  populateForm(userdetail : UserDetail){
    alert('you are in edit function')
      this.service.formData = Object.assign({},userdetail);

  }

  onDelete(UserId){
    alert('are you sure want to delete?')
      this.service.deleteUserDetail(UserId)
      .subscribe(response => {
        this.service.fetchDataList();
      },
        error=> {
          console.error();
        }
        )
  }

}
