import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { TemplateHeaderComponent } from './template-header/template-header.component';
import { TemplateSidebarComponent } from './template-sidebar/template-sidebar.component';
import { TemplateFooterComponent } from './template-footer/template-footer.component';
import { TemplateComponent } from './template/template.component';


@NgModule({
  declarations: [
    TemplateHeaderComponent,
    TemplateSidebarComponent,
    TemplateFooterComponent,
    TemplateComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule
  ]
})
export class DashboardModule { }
