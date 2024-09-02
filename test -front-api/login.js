
const url = "https://localhost:44388/api/Users/login";

async function loginUser(){
    event.preventDefault();

    var form = document.getElementById("form");

    var formData = new FormData(form);
var response = await fetch(url,{

method: 'POST',
body: formData
})

alert( " login SuccessFully Completed ");
}