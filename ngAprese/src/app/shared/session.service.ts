import { Injectable } from '@angular/core';

@Injectable()
export class SessionService {

  constructor() { }

  public Token: string;
  public Username: string;
}
