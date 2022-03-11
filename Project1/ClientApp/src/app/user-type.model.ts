export const userClaims = {
  bearerToken: "",
  isAuthenticated: true,
  claims: [
    { claimType: "canViewUserSection", claimValue: "true" },
    { claimType: "canViewOfficeAdminSection", claimValue: "false" },
    { claimType: "canViewAdminSection", claimValue: "false" }
  ],
  userRole: "User"
};

export const AdminClaims = {
  bearerToken: "",
  isAuthenticated: true,
  claims: [
    { claimType: "canViewUserSection", claimValue: "true" },
    { claimType: "canViewOfficeAdminSection", claimValue: "true" },
    { claimType: "canViewAdminSection", claimValue: "true" }
  ],
  userRole: "Admin"
};

export const OfficeAdminClaims = {
  bearerToken: "",
  isAuthenticated: true,
  claims: [
    { claimType: "canViewUserSection", claimValue: "true" },
    { claimType: "canViewOfficeAdminSection", claimValue: "true" },
    { claimType: "canViewAdminSection", claimValue: "false" }
  ],
  userRole: "OfficeAdmin"
};

export const UnAuthenticatedUser = {
  bearerToken: "",
  isAuthenticated: true,
  claims: [
    { claimType: "canViewUserSection", claimValue: "false" },
    { claimType: "canViewOfficeAdminSection", claimValue: "true" },
    { claimType: "canViewAdminSection", claimValue: "false" }
  ],
  userRole: "UnAuthenticated"
};
