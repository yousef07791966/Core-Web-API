let n =Number (localStorage.getItem("n"));
let url = `https://localhost:44388/api/Products/UpdateData${n}`;

var form = document.getElementById("form");

async function editproduct(){
event.preventDefault();
var formData = new FormData(form);

let request = await fetch(url, {
    method: 'PUT',
    body: formData,
});

var data  = response
alert("Product updated successfully");    
}
