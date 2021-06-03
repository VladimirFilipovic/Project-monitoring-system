import React, { Fragment, useEffect } from 'react';
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
import { observer } from 'mobx-react-lite';
import { useStore } from '../../stores/store';
import ModalContainer from '../common/modals/ModalContainer';
import PrivateRoute from './PrivateRoute';
import PrivateRouteLogin from './PrivateRouteLogin';
import ProjectsTable from '../../features/Projects/ProjectsTable';
import ProjectDetails from '../../features/Projects/ProjectDetails';

function App() {
  const {commonStore, userStore} = useStore()

  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser();
    } else {
    //   userStore.getFacebookLoginStatus().then(() => commonStore.setAppLoaded());
    }
  }, [commonStore, userStore])
  
  return (
    <>
      <ModalContainer/>
      <NavBar/>
      <Route  exact path='/' component={home}/>
      <Container style={{marginTop: '7em'}}>
        <PrivateRoute path='/projects-fake' component={ProjectsList}/>
        <PrivateRoute path='/requests' component={RequestsC}/>
        <PrivateRouteLogin path='/login' component={LoginForm}/>
        <Route path='/projects' component={ProjectsTable}/>
        <Route path="/projects-details/:id" component={ProjectDetails}></Route>
        {/* <Route path='/paypal' component={PayPal}/> */}
      </Container>
    </>
  );
}

export  default observer(App);
