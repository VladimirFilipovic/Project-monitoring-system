/* eslint-disable react/jsx-no-undef */
import React from 'react';
import ReactDOM from 'react-dom';
import './app/layout/styles.css';
import App from './app/layout/App';
import 'semantic-ui-css/semantic.min.css';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter, Router} from 'react-router-dom'
import { Container } from 'semantic-ui-react';
import { store, StoreContext } from './stores/store';
import {createBrowserHistory} from 'history';


export const history = createBrowserHistory();

ReactDOM.render(
  <StoreContext.Provider value={store}>
    <Router history={history}>
      <App />
    </Router>
  </StoreContext.Provider>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
