import {useMsal} from "@azure/msal-react";
import {Navigate, Outlet} from "react-router-dom";

function AuthGuard() {
    const { instance } = useMsal();
    const currUser = instance.getActiveAccount();
    
    return currUser ? <Outlet /> : <Navigate to={'/'} />;
}

export default AuthGuard;