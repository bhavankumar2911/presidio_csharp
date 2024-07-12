document
  .getElementById("form")
  .addEventListener("submit", async function (event) {
    event.preventDefault();

    const cardNumber = document.getElementById("card").value;
    const pin = document.getElementById("pin").value;

    const response = await fetch(
      "http://localhost:5230/api/Transaction/Transactions",
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          cardNumber: cardNumber,
          pin: pin,
        }),
      }
    );

    const transactions = await response.json();
    const transactionContainer = document.getElementById(
      "transaction-container"
    );

    // Clear previous transactions
    transactionContainer.innerHTML = "";

    if (Array.isArray(transactions)) {
      transactions.forEach((transaction) => {
        const transactionElement = document.createElement("div");
        transactionElement.className = "transaction";

        const transactionDetails = document.createElement("div");
        transactionDetails.className = "transaction-details";
        transactionDetails.innerHTML = `<p class="atm-name">${
          transaction.atmName
        }</p><p class="date">${new Date(
          transaction.transactionDateAndTime
        ).toLocaleString()}</p>`;

        const transactionAmount = document.createElement("div");
        transactionAmount.className = `transaction-amount ${
          transaction.transactionType === "deposit" ? "positive" : "negative"
        }`;
        transactionAmount.textContent = `${
          transaction.transactionType === "deposit" ? "+" : "-"
        } $${transaction.transactionAmount.toFixed(2)}`;

        transactionElement.appendChild(transactionDetails);
        transactionElement.appendChild(transactionAmount);

        transactionContainer.appendChild(transactionElement);
        transactionContainer.appendChild(document.createElement("hr"));
      });
    } else {
      const errorMessage = document.createElement("p");
      errorMessage.textContent = "No transactions found or an error occurred.";
      transactionContainer.appendChild(errorMessage);
    }
  });
