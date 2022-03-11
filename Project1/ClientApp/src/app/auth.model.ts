
export class AppUserAuth {
  userRole = "";
  bearerToken = "";
  isAuthenticated = false;
  claims: ClaimModel[] = [];
}
export interface ClaimModel {
  claimType: string;
  claimValue: string;
}
