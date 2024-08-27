const url = "https://localhost:44388/api/Categories";

var form = document.getElementById("form");

async function addCategory() {
  event.preventDefault();

    var formData = new FormData(form);

    let response = await fetch(url, {
    method: "POST",
    body: formData,
    });
alert( " success");
}