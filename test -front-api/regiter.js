
const url = 'https://localhost:44388/api/Users/register';
async function addUser() {
debugger;
event.preventDefault();
let form = document.getElementById("formRegister");

let formData = new FormData(form);

let response = await fetch(url,{
method: 'POST',
body : formData


    })
alert("Register successfully");
}