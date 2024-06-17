const productList = document.getElementById("product-list");

const fetchAllProducts = async () => {
  console.log("running");
  try {
    const response = await fetch("https://dummyjson.com/products");
    const products = (await response.json()).products;

    products.forEach((product) => {
      let tags = "";

      product.tags.forEach((tag) => {
        tags += `
            <span class="badge rounded-pill bg-primary-subtle text-primary-emphasis">
                ${tag}
            </span>
        `;
      });

      productList.innerHTML += `
            <div class="col-12 col-lg-6">
                <div class="row border rounded g-2" style="min-height: 100%;">
                    <div class="col-4">
                    <img
                        class="thumbnail"
                        src="${product.thumbnail}"
                    />
                    </div>
                    <div class="col-8 p-2">
                    <h3 class="fs-5">${product.title}</h3>
                    <div>
                        ${tags}
                    </div>
                    <div class="d-flex align-items-center gap-2 my-1">
                        <span class="fw-semibold fs-1 text-danger">$${product.price}</span>
                        <span class="ratings">
                        <i class="fa fa-star rating-color"></i>
                        <i class="fa fa-star rating-color"></i>
                        <i class="fa fa-star rating-color"></i>
                        <i class="fa fa-star rating-color"></i>
                        <i class="fa fa-star"></i>
                        </span>
                    </div>

                    <div class="d-grid">
                        <button class="btn btn-primary">Add to cart</button>
                    </div>
                    </div>
                </div>
                </div>
        `;
    });

    console.log(products);
  } catch (error) {
    console.log(error);
  }
};

document.addEventListener("DOMContentLoaded", fetchAllProducts);
