import { useReducer, useState } from 'react';
import './App.css';
import Login from './components/Login.tsx';
import Logout from './components/Logout.tsx';
import CreateListing from './components/CreateListing.tsx';
import ListView from './components/ListView.tsx';

function App(props) {
  
  const isLoggedInReducer = (state, action) => {

    try {
      return { value: props.getIsLoggedInRequest(props.httpService.axios, props.configurationService.appConfig) };
    }
  
    catch {
      return { value: false };
    }
  }

  const [isLoggedInDisplay, isLoggedInDisplayDispatch] = useReducer(isLoggedInReducer, { value: false });
  const [isPostsUpdated, setIsPostsUpdated] = useState({ value: false });

  return (
    <>
      {!isLoggedInDisplay.value ?
      <>
        <Login
          httpService={props.httpService}
          configurationService={props.configurationService}
          postLoginRequest={props.postLoginRequest}
          isLoggedInToggle={isLoggedInDisplayDispatch}
          label="Login" />

        <ListView
          httpService={props.httpService}
          configurationService={props.configurationService}
          getPostsRequest={props.getPostsRequest}
          isLoggedIn={isLoggedInDisplay.value} />
      </> :
      <>
        <Logout
          httpService={props.httpService}
          configurationService={props.configurationService}
          postLogoutRequest={props.postLogoutRequest}
          isLoggedInToggle={isLoggedInDisplayDispatch}
          label="Logout" />
        
        <CreateListing
          httpService={props.httpService}
          configurationService={props.configurationService}
          postAddPostRequest={props.postAddPostRequest}
          getIsPostsUpdated={isPostsUpdated}
          setIsPostsUpdated={setIsPostsUpdated}
          label="Title:" />
        
        <ListView
          httpService={props.httpService}
          configurationService={props.configurationService}
          getPostsRequest={props.getPostsRequest} />
      </>}
    </>
  );
}

export default App;
