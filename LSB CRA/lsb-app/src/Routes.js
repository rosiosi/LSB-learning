import React, {Component} from 'react';
//import PropTypes from 'prop-types';
//import { BrowserRouter as Router } from 'react-router-dom';
import Users from './Components/users/User.js'
import Words from './Components/words/Word.js'

import {Route, Switch} from 'react-router-dom';

class Routes extends Component {
    constructor(props){
        super(props);
        this.handler = this.handler.bind(this);
    }

    handler() {
        this.props.action();
    }

    render() {
        return (            
                <div>
                    <Switch>
                        <Route
                            exact path="/"
                            render = { () => (
                                <h1>Lenguaje de Señas Bolivia</h1>
                            )}
                        />
                        <Route
                            exact path="/users" component={Users}
                            
                        />
                        <Route
                            exact path="/words" component={Words}
                        />
                        <Route                           
                            render = { () => (
                                <h1>Route not found</h1>
                            )}
                        />
                    </Switch>
                </div>
               
        );
    }
}

//Routes.propTypes = {};
//Routes.defaultProps = {};

export default Routes;