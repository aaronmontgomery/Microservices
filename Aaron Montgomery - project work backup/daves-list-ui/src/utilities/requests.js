export const postAddPostRequest = (axios, appConfig, title, post) =>
    axios.post(appConfig.get('baseUrl') + '/addpost', {
        "title": title,
        "post": post
    });

export const getAddTestUserRequest = (axios, appConfig) =>
    axios.get(appConfig.get('baseUrl') + '/addtestuser');

export const getIsLoggedInRequest = (axios, appConfig) =>
    axios.get(appConfig.get('baseUrl') + '/isloggedin');

export const getPostsRequest = (axios, appConfig) =>
    axios.get(appConfig.get('baseUrl') + '/getposts');

export const postLoginRequest = (axios, appConfig, username, password) =>
    axios.post(appConfig.get('baseUrl') + '/login', {
        "username": username,
        "password": password
    });

export const postLogoutRequest = (axios, appConfig) =>
    axios.post(appConfig.get('baseUrl') + '/logout');
