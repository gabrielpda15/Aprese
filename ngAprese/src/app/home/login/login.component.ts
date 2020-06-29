import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { LoginService } from './login.service';
import { SessionService } from 'src/app/shared/session.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  constructor(private loginService: LoginService,
              private session: SessionService) { }

  private isEnabled = false;

  // tslint:disable-next-line: no-output-on-prefix
  @Output() public onExit = new EventEmitter<any>();

  @ViewChild('username', {static: false}) public username: ElementRef;
  @ViewChild('password', {static: false}) public password: ElementRef;

  ngOnInit() {
  }

  onDisable() {
    this.onExit.emit();
  }

  onSubmit() {
    this.loginService.postLogin({Username: this.username.nativeElement.value, Password: this.password.nativeElement.value}).subscribe(x => {
      console.log(x);
      if (x.Authenticated === true) {
        this.session.Username = this.username.nativeElement.value;
        this.session.Token = x.AccessToken;
        this.onDisable();
      } else {

      }
    });
  }

}
