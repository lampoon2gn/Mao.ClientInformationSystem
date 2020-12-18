import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClientComponent } from './client/client.component';
import { EmpComponent } from './emp/emp.component';

const routes: Routes = [
  {path:"",component:EmpComponent},
  {path:"emp",component:EmpComponent},
  {path:"client",component:ClientComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
