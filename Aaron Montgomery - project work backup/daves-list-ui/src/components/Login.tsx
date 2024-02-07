import React, { useState } from "react";

function Login(props) {

    const [username, setUsername] = useState('default'); // "default"
    const [password, setPassword] = useState('Testpassword#1'); // "Testpassword#1"

    const handleSubmit = (event) => {
        event.preventDefault();
        props.postLoginRequest(props.httpService.axios, props.configurationService.appConfig, username, password)
            .then(() => props.setIsLoggedIn({ value: true }));
    }

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="username">Username:</label>
                <input
                    type="text"
                    id="username"
                    name="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                    required
                />
            </div>

            <div>
                <label htmlFor="password">Password:</label>
                <input
                    type="password"
                    id="password"
                    name="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
            </div>
            
            <div>
                <button type="submit">Login</button>
            </div>
        </form>
    );
}

export default Login;
