const mo = localStorage.getItem("productId");
debugger;
let url = `https://localhost:44388/api/Products/Get one Product / by ${mo}`;

async function getAllproducts() {
  let requst = await fetch(url);
  let data = await requst.json();

  console.log(data);

  let container = document.getElementById("container");

  container.innerHTML = `

        <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card shadow-lg">
                    <img src="../images/${data.productImage}" class="card-img-top" alt="">
                    <div class="card-body text-center">
                        <h5 class="card-title">${data.productName}</h5>
                        <h5 class="card-title">${data.price}</h5>

                        <a class="btn btn-primary" href="Product.html" onclick="store(${data.productId})">Store Data</a>
                        <a href="../update.html" class="btn btn-primary > Save</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
            `;
}

function reset() {
  localStorage.clear();
}

getAllproducts();
