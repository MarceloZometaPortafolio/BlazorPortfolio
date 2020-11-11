import React from 'react';
import logo from './logo.svg';
import './App.css';
import Header from './components/Header';

function App() {
  const sections = [
    { title: 'Resume', url: 'resume' },
    { title: 'Skills', url: 'skills' },
    { title: 'Posts', url: 'posts' },
    { title: 'Projects', url: 'projects' },
    { title: 'Languages', url: 'languages' },
    { title: 'Platforms', url: 'platforms' },
    { title: 'Technologies', url: 'technologies' }
  ];

  return (
    <div className="App">
      <Header sections={sections} title={"Marcelo Zometa's Portfolio"}/>
    </div>
  );
}

export default App;
