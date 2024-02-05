import { Map } from 'immutable';

export default class ConfigurationService {
    
    constructor() {
        this.appConfig = Map({
            baseUrl: "https://localhost:7098"
        });
    }
}
