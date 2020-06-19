import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ProjectdetailsComponent } from './Projectdetails/projectdetails.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserDetailListComponent } from './user-detail-list/user-detail-list.component';
import { FormsComponent } from './Loginforms/forms.component';
import { AppRoutingModule } from './app-routing.module';
import { ProjectDetailListComponent } from './project-detail-list/project-detail-list.component';
import { ProjectDetailService } from './shared/project-detail.service';
import { UserDetailService } from './shared/user-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    ProjectdetailsComponent,
    UserDetailComponent,
    UserDetailListComponent,
    FormsComponent,
    ProjectDetailListComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ProjectDetailService,UserDetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
