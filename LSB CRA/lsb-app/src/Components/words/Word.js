import React, { Component } from 'react';
import WordList from './WordList';
//import WordService from '../../Services/WordServices.js';

import axios from 'axios';

export default class Words extends Component {

    constructor() {
        super();

        this.state = {
            words: []
        };
    }

    componentDidMount() {
        //this.setState(() => ({ words: WordService.getWords() }));
        axios.get('http://localhost:62558/api/words')
          .then((response) => {
              this.setState({
                  words: response.data               
              }                           
              );
             
          })
          .catch(error => {
              if(error.response){
                  console.log(error.responderEnd);
              }
          });
    }

    render() {
        return (
            <div>
              <div align="center">
                <h1>Palabras</h1>
              </div>              
                <div className="container-fluid" style={{marginLeft: '-15px'}}>
                  <div className="d-flex flex-row">                    
                    <div className="col-sm-12">
                        <WordList words={this.state.words} />
                    </div>
                </div>
              </div>
            </div>
        );
    }
}