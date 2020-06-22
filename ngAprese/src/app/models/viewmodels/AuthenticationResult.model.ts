export class AuthenticationResult {
  public Authenticated: boolean;
  public CreatedAt: string;
  public Expiration: string;
  public AccessToken: string;
  public Message: string;

  constructor(obj?: any) {
    this.Authenticated = obj && obj.Authenticated || false;
    this.CreatedAt = obj && obj.CreatedAt || null;
    this.Expiration = obj && obj.Expiration || null;
    this.AccessToken = obj && obj.AccessToken || null;
    this.Message = obj && obj.Message || null;
  }
}
