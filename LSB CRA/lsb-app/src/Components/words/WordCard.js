import React, {Component} from 'react';
import PropTypes from 'prop-types';
//<p className="text-justify" style={{fontSize: '14px'}}>{props.word.WordDefinition}</p> 
                           
import { Button, ModalHeader, Modal, ModalFooter, ModalBody} from 'reactstrap';

class WordCard extends Component 
{
    constructor() {
        super();

        this.state = { 
            WordID: '',
            signModal: false        
        };
    }

    toggleSignModal(){
        this.setState({
            signModal: ! this.state.signModal
        });
    }

    showSign(id){
        this.setState({          
            WordID: id,            
            signModal: ! this.state.signModal
        });
      }

    render(){
        return(

        <div>
            <Modal isOpen={this.state.signModal} toggle={this.toggleSignModal.bind(this)}>
                <ModalHeader toggle={this.toggleSignModal.bind(this)}>Seña</ModalHeader>
                <ModalBody>
                <img className="card-img-top" src={this.props.word.WordImagePath} alt="" />
                </ModalBody>
                <ModalFooter>                
                    <Button color="secondary" onClick={this.toggleSignModal.bind(this)}>Cancel</Button>
                </ModalFooter>
            </Modal>
            <div className="word-card">
                <div className="word-card card">
                    <img className="card-img-top" src={this.props.word.WordImagePath} alt="" />        
                    <div className="card-body">
                        <h4 align="center" className="card-title">{this.props.word.WordDefinition}</h4>   
                        <Button className="my-3" color="success" onClick={this.showSign.bind(this, this.props.word.WordID)}>Seña</Button>                      
                    </div>            
                </div>
            </div>
        </div>
    )
    }
}




export default WordCard;