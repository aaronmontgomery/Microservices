export default class HttpService {
    
    constructor(axios, httpResponseService) {
        
        this.authorizationToken = undefined;
        
        this.axios = axios;
        
        axios.interceptors.request.use(
            (config) => {
                config.headers['Authorization'] = 'Bearer ' + this.authorizationToken;
                config.headers['Content-Type'] = 'application/json';
                console.log('Request Interceptor:', config);
                return config;
            },
            (error) => {
                console.error('Request Error Interceptor:', error);
                return Promise.reject(error);
            }
        );
        
        axios.interceptors.response.use(
            (response) => {
                response.data['token'] = this.authorizationToken != null ? this.authorizationToken : response.data['token']; // 
                this.authorizationToken = httpResponseService.ProcessResponse(response.data);
                console.log('Response Interceptor:', response);
                return response;
            },
            (error) => {
                console.error('Response Error Interceptor:', error);
                return Promise.reject(error);
            }
        );
    }
}
