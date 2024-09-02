
const url = 'https://localhost:44388/api/Users/register';
async function addUser() {
debugger;
event.preventDefault();
    var form = document.getElementById("formRegister");

    var formData = new FormData(form);

    var response = await fetch(url,{
method: 'POST',
body : formData


    })
alert("Register successfully");
}