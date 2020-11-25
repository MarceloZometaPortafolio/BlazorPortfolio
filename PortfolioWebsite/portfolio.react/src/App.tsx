import React, {createContext} from 'react';
import { BrowserRouter, Route, Redirect, Switch} from 'react-router-dom';
import './App.css';
import Main from './components/Main';
import Projects from './components/Projects/Projects';
import Resume from './components/Resume';
import Auth from "./components/Auth";
import Callback from './components/Callback'
import DetailProject from './components/Projects/DetailProject'
import Languages from './components/Categories/Languages'

interface FormContextProps {
  values: {},
  setValue?: (fieldName: string, value: any) => void;
}

export const FormContext = createContext<FormContextProps>({
  values: {},
})

function App() {
  const posts = ["First post\n", "Second post\n", "Third post\n"]

  return (
    <div className="App">
      <Auth>
        <BrowserRouter>
          <Switch>
            <Route exact path="/" 
                  render={(props) => (<Main title="From the firehose" posts={posts}/>)}/>
            <Route exact path="/resume" 
                  component={Resume}/>
            <Route exact path="/projects" 
                  component={Projects}/>
            <Route path="/callback" 
                  component={Callback}/>
            <Route exact path="/projects/:slug" 
                  component={DetailProject}/>
            <Route exact path="/languages"
                  component={Languages}/>
          </Switch>
        </BrowserRouter>
      </Auth>
    </div>
  );
}

export default App;
