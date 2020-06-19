import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-forms',
  templateUrl: './forms.component.html',
  styleUrls: ['./forms.component.css']
})
export class FormsComponent implements OnInit {

  user ={
    username: '',
    password: ''
  };
  constructor() { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm){
    this.user.username = form.value.username;
    this.user.password = form.value.password;
    form.reset();
    console.log('UserName ' + this.user.username + " Password "+ this.user.password)
  }

}
