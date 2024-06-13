const name = document.getElementById("name");
const desc = document.getElementById("desc");
const price = document.getElementById("price");
const qty = document.getElementById("qty");
const image = document.getElementById("image");
const form = document.getElementById("form");
const tableBody = document.getElementById("table-body");

const addProductToTable = (e) => {
  e.preventDefault();

  const template = `
        <tr>
          <td>${name.value}</td>
          <td><img src="${image.value}" /></td>
          <td class="desc">${desc.value}</td>
          <td>Rs. ${price.value}</td>
          <td>${qty.value}</td>
        </tr>
    `;

  tableBody.innerHTML += template;
};

form.addEventListener("submit", addProductToTable);
