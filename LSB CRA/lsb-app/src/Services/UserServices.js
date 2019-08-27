import axios from 'axios';


export default class UserService { 
    static getUsers() {
        axios.get('http://localhost:62558/api/users')
        .then((response) => {
           return response.data;           
        })
        .catch(error => {
            if(error.response){
                console.log(error.responderEnd);
            }
        });  
        
    }
}