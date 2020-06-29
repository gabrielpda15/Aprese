import { Routes, RouterModule } from '@angular/router';
import { SystemComponent } from './system.component';
import { HomeComponent } from './home/home.component';

const childRoutes: Routes = [
  { path: '', component: HomeComponent }
];

const routes: Routes = [
  { path: '', component: SystemComponent, children: childRoutes }
];

export const routing = RouterModule.forChild(routes);
