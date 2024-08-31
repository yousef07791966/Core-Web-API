const mo = localStorage.getItem("productId");
debugger;
let url = `https://localhost:44388/api/Products/Get one Product / by ${mo}`;

async function getAllproducts() {debugger;
  let requst = await fetch(url);
  let data = await requst.json();

  console.log(data);

  let container = document.getElementById("container");

  container.innerHTML = `

        <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card shadow-lg">
                    <img src="../images/${data[0].productImage}" class="card-img-top" alt="">
                    <div class="card-body text-center">
                        <h5 class="card-title">${data[0].productName}</h5>
                        <h5 class="card-title">${data[0].price}</h5>

                        <button  type="button" class="btn btn-primary" href="Product.html" onclick="AddToCart()">Store Data</button>
                                            <input type="number"id="quantity" name="quantity" /> quantity is :

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

////////////////////////////////////////


  async function AddToCart(  ) 
  {   let url= "https://localhost:44388/api/CartItems/postData";
    let ss = document.getElementById("quantity");
    let data = {
        cartId:2,
      productId : localStorage.getItem("productId"),
      quantity: ss.value
    };
    let response = await fetch(url, {
      method: "POST",
      body:JSON.stringify(data),
      headers: {
        "Content-Type": "application/json"
      },
    });
    alert("Data saved successfully");   
  }