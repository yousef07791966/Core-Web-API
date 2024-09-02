async function getdata() {
    const userId = document.getElementById("ID").value;
    const url = `https://localhost:44388/api/Users/return/info${userId}`;
    const response = await fetch(url);
    const data = await response.json();
    const usernameInput = document.getElementById("Username");
    usernameInput.value = data.username;
    const emailInput = document.getElementById("email");
    emailInput.value = data.email;
  }