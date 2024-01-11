import {AuthenticatedTemplate, UnauthenticatedTemplate, useMsal} from "@azure/msal-react";
import {loginRequest} from "../Authenticaiton/auth-config.js";

function Home() {
    const { instance } = useMsal();
    const activeAcc = instance.getActiveAccount();
    
    const handleRedirect = () => {
        instance
            .loginRedirect({
                ...loginRequest,
                prompt: 'create',
            })
            .catch((err) => console.log(err));
    };
    
    return (
        <>
            <AuthenticatedTemplate>
                {activeAcc ? (
                    <h1>Auth templ ama e stanalo</h1>
                ) : (
                    <h1>Auth templ ama ne e stanalo</h1>
                )}
            </AuthenticatedTemplate>
            <UnauthenticatedTemplate>
                <button onClick={handleRedirect}>
                    Sign up
                </button>
            </UnauthenticatedTemplate>
        </>
    );
}

export default Home;