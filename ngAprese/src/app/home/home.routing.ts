import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { HomeContentComponent } from './content/content.component';
import { AboutComponent } from './about/about.component';

const childRoutes: Routes = [
  { path: 'about', component: AboutComponent },
  { path: '', component: HomeContentComponent}
];

const routes: Routes = [
  { path: '', component: HomeComponent, children: childRoutes }
];

export const routing = RouterModule.forChild(routes);
