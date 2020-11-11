import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import Main from './components/Main';
import Blog from './components/Blog';
import Header from './components/Header';

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
  <React.StrictMode>
    <Header sections={sections} title={"Marcelo Zometa's Portfolio"}/>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
