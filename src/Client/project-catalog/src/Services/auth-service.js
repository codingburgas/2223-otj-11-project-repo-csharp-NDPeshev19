import {PublicClientApplication} from "@azure/msal-browser";
import {msalConfig} from "../Authenticaiton/auth-config.js";

export const msalInstance = new PublicClientApplication(msalConfig);

