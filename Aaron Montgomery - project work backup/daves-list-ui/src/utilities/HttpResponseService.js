export default class HttpResponseService {
    
    handleError(error) {

        if (error.code === "ERR_NETWORK") {
            return;
        }

        else {
            window.location.assign('/');
        }
    }
    
    handleResponse(baseResponse) {
        
        switch (baseResponse.serverAction) {

            case 0: // IsLoggedIn

                break;
            
            case 1: // Login

                break;
            
            case 2: // Logout
                window.location.assign('/'); // home
                break;

            default:
                break;
                //throw new Error("HttpResponseService ProcessResponse serverAction unknown");
        }
    }
}
