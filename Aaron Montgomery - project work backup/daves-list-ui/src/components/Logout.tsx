import React from "react";

function Logout(props) {
    
    const handleSubmit = (event) => {
        event.preventDefault();
        props.postLogoutRequest(props.httpService.axios, props.configurationService.appConfig)
            .then(() => props.setIsLoggedIn({ value: true }));
    }

    return (
        <form onSubmit={handleSubmit}>
            <button type="submit">{props.label}</button>
        </form>
    );
}

export default Logout;
