import { useReducer } from 'react';
import './App.css';
import Login from './components/Login.tsx';
import Logout from './components/Logout.tsx';
import CreateListing from './components/CreateListing.tsx';

function App(props) {
  
  const [isLoggedIn, isLoggedIndispatch] = useReducer((state, action) => ({ display: !state.display }), { display: false });

  return (
    <div>
      {!isLoggedIn.display ?
      <>
        <Login
          httpService={props.httpService}
          configurationService={props.configurationService}
          postLoginRequest={props.postLoginRequest}
          isLoggedInToggle={isLoggedIndispatch}
          label="Login" />
      </> :
      <>
        <Logout
          httpService={props.httpService}
          configurationService={props.configurationService}
          postLogoutRequest={props.postLogoutRequest}
          isLoggedInToggle={isLoggedIndispatch}
          label="Logout" />
        
        <CreateListing />

      </>}
    </div>
  );
}

export default App;
