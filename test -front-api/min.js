
let url = "https://localhost:44388/api/Categories/Get all categories";

async function getAllproducts(){

    let requst = await fetch(url);
    let data = await requst.json();

    let container = document.getElementById("container");
    data.forEach(products => {

        container.innerHTML +=   `

        <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-4">
                <div class="card shadow-lg">
                    <img src="../images/${products.categoryImage}" class="card-img-top" alt="">
                    <div class="card-body text-center">
                        <h5 class="card-title">${products.categoryName}</h5>
                        <a class="btn btn-primary" href="Product.html" onclick="store(${products.categoryId})">Store Data</a>
                        </div>
                </div>
            </div>
        </div>
    </div>
            `
        
    });
}

function reset() {
    localStorage.clear(); 

}

function store(id) {
    localStorage.categoryId =id ;

}

debugger;
function saveID(){

    localStorage.cartId =1;
}
getAllproducts();
