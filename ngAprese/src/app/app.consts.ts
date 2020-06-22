import { HttpHeaders } from '@angular/common/http';

export const API_ENDPOINT = 'http://localhost/Aprese/api';

export function getHttpOptions(token: string) {
  if (token == null){
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'Token ' + token,
        Accept: 'application/json'
      })
    };
  }

  return {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: token,
      Accept: 'application/json'
    })
  };
}
