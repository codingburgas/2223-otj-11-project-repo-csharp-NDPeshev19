export const msalConfig = {
    auth: {
        clientId: import.meta.env.VITE_CLIENTID,
        authority: `https://login.microsoftonline.com/${import.meta.env.VITE_TENANTID}`,
        redirectUri: '/',
        postLogoutRedirectUri: '/',
        navigateToLoginRequestUrl: false,
    },
    cache: {
        cacheLocation: 'sessionStorage',
        storeAuthStateInCookie: false,
    },
};
export const loginRequest = {
    scopes: ['user.read'],
}