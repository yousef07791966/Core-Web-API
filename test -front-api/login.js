
const url = "https://localhost:44388/api/Users/login";

async function loginUser(){
    debugger;
    event.preventDefault();

    let form = document.getElementById("form");

    let formData = new FormData(form);
    let response = await fetch(url,{

method: 'POST',
body: formData
})

let result = await response.json();
localStorage.setItem('jwtToken', result.token);/// new
alert( " login SuccessFully Completed ");
}