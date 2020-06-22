import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { API_ENDPOINT, getHttpOptions } from 'src/app/app.consts';
import { stringify } from '@angular/compiler/src/util';
import { SessionService } from 'src/app/shared/session.service';
import { LoginUser } from 'src/app/models/viewmodels/LoginUser.model';
import { AuthenticationResult } from 'src/app/models/viewmodels/AuthenticationResult.model';

@Injectable()
export class LoginService {

  constructor(private http: HttpClient, private session: SessionService) { }

  public postLogin(user: LoginUser): Observable<AuthenticationResult> {
    return this.http.post<any>(`${API_ENDPOINT}/login`, JSON.stringify(user), getHttpOptions(null))
                .pipe(map(x => new AuthenticationResult(x)));
  }
}
