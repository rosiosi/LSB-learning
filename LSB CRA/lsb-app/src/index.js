import React from 'react';
import ReactDOM from 'react-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

import FullPage from "./Components/FullPage.js";

import './index.css';

import * as serviceWorker from './serviceWorker';

import { browserHistory } from 'react-router-v3';
import { BrowserRouter as Router } from 'react-router-dom';



ReactDOM.render(<Router history={browserHistory}>
                <FullPage />
                </Router>, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();