import { useEffect, useState } from 'react';
import './App.css';
import Login from './components/Login.tsx';
import Logout from './components/Logout.tsx';
import CreateListing from './components/CreateListing.tsx';
import ListView from './components/ListView.tsx';

function App(props) {
  
  const [isLoggedIn, setIsLoggedIn] = useState({ value: false });
  const [isPostsUpdated, setIsPostsUpdated] = useState({ value: false });
  
  useEffect(() => {
    const getIsLoggedIn = async () => await props.getIsLoggedInRequest(props.httpService.axios, props.configurationService.appConfig);
    getIsLoggedIn().catch(() => setIsLoggedIn({ value: false }));
  }, [props])

  return (
    <>
      {!isLoggedIn.value ?
      <>
        <Login
          httpService={props.httpService}
          configurationService={props.configurationService}
          postLoginRequest={props.postLoginRequest}
          setIsLoggedIn={setIsLoggedIn}
          label="Login" />

        <ListView
          httpService={props.httpService}
          configurationService={props.configurationService}
          getPostsRequest={props.getPostsRequest}
          isLoggedIn={isLoggedIn.value} />
      </> :
      <>
        <Logout
          httpService={props.httpService}
          configurationService={props.configurationService}
          postLogoutRequest={props.postLogoutRequest}
          setIsLoggedIn={setIsLoggedIn}
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
