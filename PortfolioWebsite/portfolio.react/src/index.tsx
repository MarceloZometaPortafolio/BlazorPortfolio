import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import Header from './components/Header';
import { makeStyles } from '@material-ui/core/styles';
import { Auth0Provider } from '@auth0/auth0-react';


const useStyles = makeStyles((theme) => ({
  body: {
    minHeight: "100vh"
  },
  footer: {
    bottom: "0",
    position: "absolute",
    width: "100%"
  }
}));

const sections = [
  { title: 'Resume', url: 'resume' },
  { title: 'Skills', url: 'skills' },
  { title: 'Posts', url: 'posts' },
  { title: 'Projects', url: 'projects' },
  { title: 'Languages', url: 'languages' },
  { title: 'Platforms', url: 'platforms' },
  { title: 'Technologies', url: 'technologies' }
];

ReactDOM.render(
  <Auth0Provider
    domain="dev--qt6q8jb.us.auth0.com"
    clientId="g3xe8dMB0u1PIq1EdPzRjpqZXDEUt0Yh"
    redirectUri={window.location.origin}
  >
    <React.StrictMode>
      <Header sections={sections} title={"Marcelo Zometa's Portfolio"}/>
      <App/>      
    </React.StrictMode>  
  </Auth0Provider>,  
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
