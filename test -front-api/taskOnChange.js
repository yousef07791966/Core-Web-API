const url = "https://localhost:44388/api/Users/return/info";

const form = document.getElementById("userForm");
const userNameInput = document.getElementById("username");
userNameInput.addEventListener("change",getUserInfo)
form.addEventListener("submit", (e) => {
  e.preventDefault();
});
async function getUserInfo() {
  const formData = new FormData(form);
  const response = await fetch(url, {
    method: "POST",
    body: formData,
  });
  if (response.ok) {
   const data = await response.json();

   for (const key in data) {
    document.getElementById("contant").innerHTML += `
        <div class="mb-3">
            <strong class="text-capitalize">${key}:</strong> 
            <span class="text-muted">${data[key]}</span>
        </div>
    `;
}
  }
}

