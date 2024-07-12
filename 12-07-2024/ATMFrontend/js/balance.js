import { API_HOST } from "./config.js";

const d = document;
const card = d.getElementById("card");
const pin = d.getElementById("pin");
const atm = d.getElementById("atm");
const form = d.getElementById("form");
const accNo = d.getElementById("accNo");
const bankName = d.getElementById("bankName");
const accType = d.getElementById("accType");
const balance = d.getElementById("balance");
const loader = d.getElementById("loader");
const content = d.getElementById("content");

const fetchBalance = async (e) => {
  e.preventDefault();

  if (!card.value || !pin.value) return alert("All fields are required.");

  loader.classList.remove("b-none");
  content.classList.add("b-none");

  try {
    const response = await fetch(`${API_HOST}/api/Transaction/GetBalance`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        cardNumber: card.value,
        pin: pin.value,
        atmId: atm.value,
      }),
    });

    loader.classList.add("b-none");

    const data = await response.json();

    if (!response.ok) {
      return alert(data.message);
    }

    accNo.innerText = data.accountId;
    accType.innerText = data.type;
    bankName.innerText = data.atmName;
    balance.innerText = data.balanceAmount;
    content.classList.remove("b-none");

    console.log(data);
  } catch (error) {
    console.error(error);
  }
};

form.addEventListener("submit", fetchBalance);
