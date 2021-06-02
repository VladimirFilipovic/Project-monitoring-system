import React, { Fragment } from 'react';
import { Route } from 'react-router';
import { Container } from 'semantic-ui-react';
import home from '../../features/Home/home';
import NavBar from './NavBar';
import "bootstrap/dist/css/bootstrap.min.css";
import "@fortawesome/fontawesome-free/css/all.css";
import "@fortawesome/fontawesome-free/js/all.js";
import './styles.css';
import ProjectsList from '../../features/Projects/Projects';
import RequestsC from '../../features/Requests/RequestsC';
import LoginForm from '../../features/users/LoginForm';

function App() {
  return (
    <>
      <NavBar/>
      <Route  exact path='/' component={home}/>
      <Container style={{marginTop: '7em'}}>
        <Route path='/projects' component={ProjectsList}/>
        <Route path='/requests' component={RequestsC}/>
        <Route path='/login' component={LoginForm}/>
      </Container>
    </>
  );
}

export default App;
