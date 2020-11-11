import React, {createContext} from 'react';
import { BrowserRouter, Route, Redirect, Switch} from 'react-router-dom';
import './App.css';
import Main from './components/Main';
import Projects from './components/Projects/Projects';

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
      <BrowserRouter>
        <Route exact path="/" 
               render={(props) => (<Main title="From the firehose" posts={posts}/>)}
        />
        <Route exact path="/projects" component={Projects}/>
      </BrowserRouter>
    </div>
  );
}

export default App;
