import {BrowserRouter, Route, Routes} from 'react-router-dom'
import {lazy, Suspense} from "react";
import AuthGuard from "./Utils/auth-guard.jsx";

const HomePage = lazy(() => import("./Pages/home.jsx"))
const SecretPage = lazy(() => import("./Pages/secret.jsx"));
function App() {
    return (
        <Suspense fallback={<p>Loading...</p>}>
            <BrowserRouter>
                <Routes>
                    <Route path={"/"} element={<HomePage/>}/>
                    <Route element={<AuthGuard />}>
                        <Route path={"/secret"} element={<SecretPage/>}/>
                    </Route>
                </Routes>
            </BrowserRouter>
        </Suspense>
    );
}

export default App
