import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SystemComponent } from './system.component';
import { routing } from './system.routing';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home/home.component';



@NgModule({
  declarations: [ SystemComponent, HomeComponent ],
  imports: [ CommonModule, routing, SharedModule ]
})
export class SystemModule { }
