import React, {Component} from 'react';
import { Table, Button, ModalHeader, Modal, ModalFooter, ModalBody, Label, Input, FormGroup} from 'reactstrap';

import axios from 'axios';
//import UserService from '../../Services/UserServices.js'


class User extends Component {
  constructor() {
    super();

    this.state = {
      users: [],
      newUserData: {
        UserName: '',
        UserLastName: '',
        UserUserName: ''
      },
      editUserData: {
        UserID: '',
        UserName: '',
        UserLastName: '',
        UserUserName: ''
      },
      newUserModal: false,
      editUserModal: false
    }
}
  

  componentDidMount(){
    this.refreshUsers();    
  }; 

  toggleUsersModal(){
   this.setState({
    newUserModal: ! this.state.newUserModal
   });
  }

  toggleEditUserModal(){
    this.setState({
     editUserModal: ! this.state.editUserModal
    });
   }


  addUser() {
    axios.post('http://localhost:62558/api/users', this.state.newUserData).then((response) =>{
      let { users } = this.state;
      users.push(response.data);
      this.setState({ users, newUserModal: false, newUserData: {
        UserName: '',
        UserLastName: '',
        UserUserName: ''
      }});
    });
  }

  editUser(id, name, lastName, userName){
    this.setState({
      editUserData: { 
        UserID: id,
        UserName: name,
        UserLastName: lastName,
        UserUserName: userName
       },
      editUserModal: ! this.state.editUserModal
    });
  }

  deleteUser(id){
    axios.delete('http://localhost:62558/api/users/' + id).then((response) =>{
      this.refreshUsers();
    });
  }

  refreshUsers(){ 
    axios.get('http://localhost:62558/api/users')
        .then((response) => {
            this.setState({
                users: response.data               
            }                           
            );
           
        })
        .catch(error => {
            if(error.response){
                console.log(error.responderEnd);
            }
        });
  }

  updateUser(){   
    axios.put('http://localhost:62558/api/users/' + this.state.editUserData.UserID, 
              this.state.editUserData).then((response) => {

              var objIndex = this.state.users.findIndex((obj => obj.UserID === this.state.editUserData.UserID));  
              
              this.state.users[objIndex].UserName = this.state.editUserData.UserName;
              this.state.users[objIndex].UserLastName = this.state.editUserData.UserLastName;
              this.state.users[objIndex].UserUserName = this.state.editUserData.UserUserName;
              
              
      //this.refreshUsers();
      this.setState({
        editUserData: { 
          UserID: '',
          UserName: '',
          UserLastName: '',
          UserUserName: ''
         },
        editUserModal: false
      });
    });
  }


  

  render(){  
    let users = this.state.users.map((user) => {
        return (
            <tr key={user.UserID}>
                <td>{user.UserID}</td>
                <td>{user.UserName} {user.UserLastName}</td>
                <td>{user.UserUserName}</td>
                <td>
                    <Button color="success" size="sm" className="mr-2" 
                            onClick={this.editUser.bind(this, user.UserID, user.UserName, user.UserLastName, user.UserUserName)}>Edit</Button>
                    <Button color="danger" size="sm" onClick={this.deleteUser.bind(this, user.UserID)}>Delete</Button>
                </td>
            </tr>
        )
    });
    

    return (
      <div className="App container"> 

      <h1>LSB App</h1>

        <Button className="my-3" color="primary" onClick={this.toggleUsersModal.bind(this)}>Add User</Button>

        <Modal isOpen={this.state.newUserModal} toggle={this.toggleUsersModal} className={this.props.className}>
          <ModalHeader toggle={this.toggleUsersModal.bind(this)}>New User</ModalHeader>
          <ModalBody>
          <FormGroup>
              <Label for="userName" className="mr-2">Name</Label>
              <Input id="userName" value={this.state.newUserData.UserName} 
                                        onChange={(e) => { let { newUserData } = this.state;
                                        newUserData.UserName = e.target.value;
                                        this.setState( { newUserData } );
                              }} placeholder="Enter the firstName" />
             
            </FormGroup>
            <FormGroup>
              <Label for="userLastName" className="mr-2">LastName</Label>
              <Input id="userLastName" value={this.state.newUserData.UserLastName}
                                        onChange={(e) => { let { newUserData } = this.state;
                                        newUserData.UserLastName = e.target.value;
                                         this.setState( { newUserData } );
                              }}  placeholder="Enter the LastName" />
            </FormGroup>
            <FormGroup>
              <Label for="userUserName" className="mr-2">UserName</Label>
              <Input id="userUserName" value={this.state.newUserData.UserUserName} 
                                      onChange={(e) => { let { newUserData } = this.state;
                                      newUserData.UserUserName = e.target.value;
                                      this.setState( { newUserData } );
                            }}placeholder="Enter the userName" />
            </FormGroup>
          </ModalBody>
          <ModalFooter>
            <Button color="primary" onClick={this.addUser.bind(this)}>Add User</Button>
            <Button color="secondary" onClick={this.toggleUsersModal.bind(this)}>Cancel</Button>
          </ModalFooter>
        </Modal>

        <Modal isOpen={this.state.editUserModal} toggle={this.toggleEditUserModal.bind(this)}>
          <ModalHeader toggle={this.toggleEditUserModal.bind(this)}>Edit User</ModalHeader>
          <ModalBody>
          <FormGroup>
              <Label for="userName" className="mr-2">Name</Label>
              <Input id="userName" value={this.state.editUserData.UserName} 
                                        onChange={(e) => { let { editUserData } = this.state;
                                        editUserData.UserName = e.target.value;
                                        this.setState( { editUserData } );
                              }} placeholder="Enter the firstName" />
             
            </FormGroup>
            <FormGroup>
              <Label for="userLastName" className="mr-2">LastName</Label>
              <Input id="userLastName" value={this.state.editUserData.UserLastName}
                                        onChange={(e) => { let { editUserData } = this.state;
                                        editUserData.UserLastName = e.target.value;
                                         this.setState( { editUserData } );
                              }}  placeholder="Enter the LastName" />
            </FormGroup>
            <FormGroup>
              <Label for="userUserName" className="mr-2">UserName</Label>
              <Input id="userUserName" value={this.state.editUserData.UserUserName} 
                                      onChange={(e) => { let { editUserData } = this.state;
                                      editUserData.UserUserName = e.target.value;
                                      this.setState( { editUserData } );
                            }}placeholder="Enter the userName" />
            </FormGroup>
          </ModalBody>
          <ModalFooter>
            <Button color="primary" onClick={this.updateUser.bind(this)}>Update User</Button>
            <Button color="secondary" onClick={this.toggleEditUserModal.bind(this)}>Cancel</Button>
          </ModalFooter>
        </Modal>


        <Table>
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>UserName</th>
              <th>Action</th>
            </tr>  
          </thead>
          <tbody>
            {users}
          </tbody>
        </Table>     
      </div>
    );    

  }
  
}

export default User;