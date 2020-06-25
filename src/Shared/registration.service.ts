import {Injectable} from '@angular/core';
import { Form, FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn : 'root'
})

export class RegistrationService{
    constructor (public fb: FormBuilder, public http: HttpClient){}

    readonly baseURl = 'http://localhost:51386/api' 

    FormModel = this.fb.group({
        Id :'',
        UserName : ['',Validators.required],
        Email : ['',Validators.email],
        FullName :[''],
        Passwords:this.fb.group({
            Password:['',[Validators.required,Validators.minLength(8)]],
            ConfirmPassword : ['',Validators.required]
        },{validator : this.comparePassword} )
    }); 

    comparePassword(fb:FormGroup){
        let confirmPswrd = fb.get('ConfirmPassword')
        if(confirmPswrd.errors == null || 'passwordMismatch' in confirmPswrd.errors) {
            if(fb.get('Password').value != confirmPswrd.value)
                confirmPswrd.setErrors({passwordMismatch : true})
            else
                confirmPswrd.setErrors(null)
        }
    }

    register(){
        var body = {
           // Id : this.FormModel.value.Id,
            UserName : this.FormModel.value.UserName,
            Email : this.FormModel.value.Email,
            FullName : this.FormModel.value.FullName,
            Password : this.FormModel.value.Passwords.Password,
            ConfirmPassword : this.FormModel.value.Passwords.ConfirmPassword,
        };
      return this.http.post(this.baseURl + '/RegistrationDetails',body);
    }
}