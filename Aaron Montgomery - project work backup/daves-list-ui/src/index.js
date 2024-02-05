import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import axios from 'axios';
import HttpService from './utilities/HttpService';
import HttpResponseService from './utilities/HttpResponseService';
import ConfigurationService from './utilities/ConfigurationService';
import { getIsLoggedInRequest, postLoginRequest, postLogoutRequest } from './utilities/requests';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App
      httpService={new HttpService(axios, new HttpResponseService())}
      configurationService={new ConfigurationService()}
      getIsLoggedInRequest={getIsLoggedInRequest}
      postLoginRequest={postLoginRequest}
      postLogoutRequest={postLogoutRequest}
    />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
