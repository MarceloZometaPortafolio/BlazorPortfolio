import React from 'react'
import { useAuth0 } from "@auth0/auth0-react";
import Login from './Login';
import Logout from './Logout';

const AuthenticateButton = () => {
    const { user, isAuthenticated, isLoading } = useAuth0();

    if (isLoading) {
        return <div>Loading...</div>;
    }

    return(
        isAuthenticated ? (
            <div>
                Hello, {user.name}  
                <Logout/>
            </div>
        ) : 
        (
            <div>
                <Login/>
            </div>
        )
    );
}

export default AuthenticateButton