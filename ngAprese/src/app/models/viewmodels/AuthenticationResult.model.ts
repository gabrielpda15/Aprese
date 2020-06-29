export class AuthenticationResult {
  public Authenticated: boolean;
  public CreatedAt: string;
  public Expiration: string;
  public AccessToken: string;
  public Message: string;

  constructor(obj?: any) {
    this.Authenticated = obj && obj.authenticated || false;
    this.CreatedAt = obj && obj.createdAt || null;
    this.Expiration = obj && obj.expiration || null;
    this.AccessToken = obj && obj.accessToken || null;
    this.Message = obj && obj.message || null;
  }
}
