import React, {Component} from 'react';

import Routes from '../Routes'

class FullPage extends Component{
    render(){
        return (
          <div>                
                <Routes />                      
          </div>  
        );
    }
}

FullPage.defaultProps = {};

export default FullPage;