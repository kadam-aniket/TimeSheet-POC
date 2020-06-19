import {NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsComponent } from './Loginforms/forms.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { ProjectdetailsComponent } from './Projectdetails/projectdetails.component';

const routes : Routes=[
    {path:'login',component: FormsComponent},
    {path:'home', component: FormsComponent},
    {path:'user', component: UserDetailComponent},
    {path:'project', component: ProjectdetailsComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}