debugger;
const mo = localStorage.getItem("categoryId");

let url = `https://localhost:44388/api/Products/  category ${mo}`;

async function getAllproducts() {
  let requst = await fetch(url);
  let data = await requst.json();

  let container = document.getElementById("container");
  data.forEach((products) => {
    container.innerHTML += `

         <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card shadow-lg">
                    <img src="../images/${products.productImage}" class="card-img-top" alt="">
                    <div class="card-body text-center">
                        <h5 class="card-title">${products.productName}</h5>
                        <a class="btn btn-primary" href="detalies.html" onclick="store(${products.productId})">Store Data</a>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
            `;
  });
}

///////

let url2 = `https://localhost:44388/api/Products/Get all Products`;

async function getAll() {
  let requst = await fetch(url2);
  let data = await requst.json();

  let container = document.getElementById("container");
  data.forEach((products) => {
    container.innerHTML += `

         <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card shadow-lg">
                    <img src="../images/${products.productImage}" class="card-img-top" alt="">
                    <div class="card-body text-center">
                        <h5 class="card-title">${products.productName}</h5>
                        <a class="btn btn-primary" href="detalies.html" onclick="store(${products.productId})">Store Data</a>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
            `;
  });
}

function reset() {
  localStorage.clear();
}

function store(id) {
  localStorage.productId = id;
}
if (localStorage.getItem("categoryId") == null) {
  getAll();
} else {
  getAllproducts();
}
