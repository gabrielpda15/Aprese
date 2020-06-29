import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from '../shared/session.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(public router: Router, public session: SessionService) { }

  public showLogin = false;

  ngOnInit() {
  }

  public isLoggedIn(): boolean {
    return this.session?.Token != null;
  }

  public onLoginDisable() {
    this.showLogin = false;
  }

  public onLoginClick(): void {
    this.showLogin = true;
  }

}
