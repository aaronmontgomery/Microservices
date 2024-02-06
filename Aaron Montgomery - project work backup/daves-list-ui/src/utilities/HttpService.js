export default class HttpService {
    
    constructor(axios, httpResponseService) {
        
        this.axios = axios;
        
        this.authorizationToken = undefined;

        this.request = null;

        this.requestInterceptor = axios.interceptors.request.use(
            (config) => {
                config.headers['Authorization'] = 'Bearer ' + this.authorizationToken;
                config.headers['Content-Type'] = 'application/json';
                console.log('Request Interceptor:', config);
                this.request = config;
                return config;
            },
            (error) => {
                console.error('Request Error Interceptor:', error);
                return Promise.reject(error);
            }
        );
        
        this.responseInterceptor = axios.interceptors.response.use(
            (response) => {
                this.authorizationToken = this.authorizationToken != null ? this.authorizationToken : response.data['token'];
                httpResponseService.handleResponse(response.data);
                console.log('Response Interceptor:', response);
                return response;
            },
            (error) => {
                httpResponseService.handleError(error);
                console.error('Response Error Interceptor:', error);
                return Promise.reject(error);
            }
        );
    }
}
