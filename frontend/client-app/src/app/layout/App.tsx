import React, { Fragment } from 'react';
import { Route } from 'react-router';
import { Container } from 'semantic-ui-react';
import home from '../../features/Home/home';
import Projects from '../../features/Projects/Projects';
import Requests from '../../features/Requests/Requests';
import NavBar from './NavBar';
import './styles.css';

function App() {
  return (
    <>
      <NavBar/>
      <div className='no-scroll'>
      <Route exact path='/' component={home}/>
      </div>
      <Container style={{marginTop: '7em'}}>
        <Route path='/projects' component={Projects}/>
        <Route path='/request' component={Requests}/>
      </Container>
    </>
  );
}

export default App;
