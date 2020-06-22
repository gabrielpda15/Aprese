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

  @Output() public disabled = new EventEmitter<boolean>();

  @ViewChild('username', {static: false}) public username: ElementRef;
  @ViewChild('password', {static: false}) public password: ElementRef;

  ngOnInit() {
  }

  onDisable(event: boolean) {
    this.disabled.emit(event);
  }

  onSubmit(event: any) {
    this.loginService.postLogin({Username: this.username.nativeElement.value, Password: this.password.nativeElement.value}).subscribe(x => {
      if (x.Authenticated === true) {
        this.session.Username = this.username.nativeElement.value;
        this.session.Token = x.AccessToken;
        this.onDisable(true);
      } else {

      }
    });
  }

}
