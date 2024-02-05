export default class HttpResponseService {

    ProcessResponse(baseResponse) {
        
        switch (baseResponse.serverAction) {
            
            case 0: // IsLoggedIn
                return baseResponse.token;
            
            case 1: // Login
                return baseResponse.token;
            
            case 2: // Logout
                return undefined;
            
            default:
                throw new Error("HttpResponseService ProcessResponse serverAction unknown");
        }
    }
}
