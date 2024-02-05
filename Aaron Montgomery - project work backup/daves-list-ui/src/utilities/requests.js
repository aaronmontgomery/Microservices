export const getIsLoggedInRequest = (axios, appConfig) =>
    axios.get(appConfig.get('baseUrl') + '/isloggedin');

export const postLoginRequest = (axios, appConfig, username, password) =>
    axios.post(appConfig.get('baseUrl') + '/login', {
        "username": username,
        "password": password
    });

export const postLogoutRequest = (axios, appConfig) =>
    axios.post(appConfig.get('baseUrl') + '/logout');
