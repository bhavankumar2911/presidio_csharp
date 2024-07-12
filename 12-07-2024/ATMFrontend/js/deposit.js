import { API_HOST } from "./config.js";

const d = document;
const card = d.getElementById("card");
const pin = d.getElementById("pin");
const amount = d.getElementById("amount");
const form = d.getElementById("form");
const atm = d.getElementById("atm");

const deposit = async (e) => {
  e.preventDefault();

  if (!card.value || !amount.value || !pin.value || !atm.value)
    return alert("All fields are required.");

  try {
    const response = await fetch(`${API_HOST}/api/Transaction/Deposit`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        cardNumber: card.value,
        pin: pin.value,
        amount: amount.value,
        atmId: atm.value,
      }),
    });

    if (!response.ok) {
      const data = await response.json();
      return alert(data.message);
    }

    alert(await response.text());
    return (location.href = "/balance");
  } catch (error) {
    console.error(error);
  }
};

form.addEventListener("submit", deposit);
