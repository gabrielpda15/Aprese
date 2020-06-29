import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { LoginComponent } from './login/login.component';
import { AboutComponent } from './about/about.component';
import { HomeContentComponent } from './content/content.component';
import { routing } from './home.routing';
import { SharedModule } from '../shared/shared.module';
import { LoginService } from './login/login.service';



@NgModule({
  declarations: [HomeComponent, LoginComponent, AboutComponent, HomeContentComponent],
  imports: [CommonModule, routing, SharedModule],
  providers: [LoginService]
})
export class HomeModule { }
