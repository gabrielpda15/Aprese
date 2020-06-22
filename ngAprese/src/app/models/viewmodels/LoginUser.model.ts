export class LoginUser {

  public Username: string = null;
  public Password: string = null;

  constructor(obj?: any) {
    this.Username = obj && obj.Username || null;
    this.Password = obj && obj.Password || null;
  }
}
