import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import {msalInstance} from "./Services/auth-service.js";
import {EventType} from "@azure/msal-browser";
import {MsalProvider} from "@azure/msal-react";

msalInstance.addEventCallback((e) => {
    if (e.eventType === EventType.LOGIN_SUCCESS && e.payload.account) {
        const acc = e.payload.account;
        msalInstance.setActiveAccount(acc);
    }
})

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
      <MsalProvider instance={msalInstance}>
        <App />
      </MsalProvider>
  </React.StrictMode>,
)
