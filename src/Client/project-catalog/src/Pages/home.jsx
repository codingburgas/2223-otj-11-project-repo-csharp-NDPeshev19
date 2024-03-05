import {AuthenticatedTemplate, UnauthenticatedTemplate, useMsal} from "@azure/msal-react";
import {loginRequest, protectedResources} from "../Authenticaiton/auth-config.js";
import useFetchWithMsal from "../hooks/useFetchWithMSAL.js";

function Home() {
    const {instance} = useMsal();
    const activeAcc = instance.getActiveAccount();
    
    const makeRequest = async () => {
        // eslint-disable-next-line react-hooks/rules-of-hooks
        // const {err, execute} = useFetchWithMsal({scopes: protectedResources.toDoListAPI.scopes.read});
        //
        // const data = await execute("POST", "https://localhost:7025/test");
        // console.log("Data", data);
        // console.log("error!?!!", err);
        const headers = new Headers();
        const bearer = `Bearer ${activeAcc.acce}`
        console.log("Molikanooooooo", activeAcc);
        const data = await fetch("https://localhost:7025/test", {method: "POST"});
        console.log(data);
    }

    const
    handleRedirect = () => {
        instance
            .loginRedirect({
                ...loginRequest,
                prompt: 'create',
            })
            .catch((err) => console.log(err));
    };

    const handleLogout = () => {
        instance
            .logout()
            .catch((err) => console.log(err));
    }

    if (activeAcc) {
        console.log("ACTIVE ACCOUNT:", activeAcc ?? "no");
        // console.log("ID TOKEN CLAIMS", activeAcc.idTokenClaims.roles );
    }

    return (
        <>
            <AuthenticatedTemplate>
                {activeAcc ? (
                    <>
                        <h1>Auth templ ama e stanalo</h1>
                        <button onClick={handleLogout}>
                            logout
                        </button>
                    </>
                ) : (
                    <h1>Auth templ ama ne e stanalo</h1>
                )}
            </AuthenticatedTemplate>
            <UnauthenticatedTemplate>
                <button onClick={handleRedirect}>
                    Sign up
                </button>
            </UnauthenticatedTemplate>

            <button onClick={makeRequest}>make reqest</button>
        </>
    );
}

export default Home;