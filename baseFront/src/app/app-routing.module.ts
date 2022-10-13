import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./pages/login/login.module').then(x => x.LoginModule)
  },
  {
    path: 'dashboard',
    loadChildren: () => import("./pages/dashboard/dashboard.module").then(x => x.DashboardModule)
  }
];

@NgModule({
  //imports: [RouterModule.forRoot(routes)],
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
