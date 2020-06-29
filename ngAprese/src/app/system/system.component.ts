import { Component, OnInit } from '@angular/core';
import { SessionService } from '../shared/session.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-system',
  templateUrl: './system.component.html'
})
export class SystemComponent implements OnInit {

  constructor(public session: SessionService,
              private router: Router) { }

  ngOnInit() {
  }

  public getRoute(route: string): boolean {
    let curRoute = '';

    if (this.router.url.startsWith('/system/storage')) {
      curRoute = 'st';
    } else if (this.router.url.startsWith('/system/sales')) {
      curRoute = 'sl';
    } else if (this.router.url.startsWith('/system/finance')) {
      curRoute = 'fi';
    }

    return curRoute === route;
  }

}
