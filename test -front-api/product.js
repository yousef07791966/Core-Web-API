
debugger



async function getAllproducts() {
  debugger
  const mo = localStorage.getItem("categoryId");
  if(mo != undefined){
    var url = `https://localhost:44388/api/Products/category${mo}`;
  }else{
    var url = `https://localhost:44388/api/Products`;
  }
  let token = localStorage.getItem('jwtToken');
  let requst = await fetch(url,{
    headers: {
      'Authorization': `Bearer ${token}`
  }});
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

// let url2 = `https://localhost:44388/api/Products/Get all Products`;

// async function getAll() {
//   debugger
//   let token = localStorage.getItem('jwtToken');
//   let requst = await fetch(url2,{
//     headers: {
//       'Authorization': `Bearer ${token}`
//   }});
//   let data = await requst.json();

//   let container = document.getElementById("container");
//   data.forEach((products) => {
//     container.innerHTML += `

//          <div class="container mt-5">
//         <div class="row justify-content-center">
//             <div class="col-md-4">
//                 <div class="card shadow-lg">
//                     <img src="../images/${products.productImage}" class="card-img-top" alt="">
//                     <div class="card-body text-center">
//                         <h5 class="card-title">${products.productName}</h5>
//                         <a class="btn btn-primary" href="detalies.html" onclick="store(${products.productId})">Store Data</a>
                        
//                     </div>
//                 </div>
//             </div>
//         </div>
//     </div>
//             `;
//   });
// }

function reset() {
  localStorage.removeItem("categoryId");
}

function logout() {
  localStorage.removeItem('jwtToken');
  window.location.href = 'index.html';
}

function store(id) {
  localStorage.productId = id;
}

  getAllproducts();

