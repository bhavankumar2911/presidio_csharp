document.getElementById('form').addEventListener('submit', function (event) {
    event.preventDefault();

    const cardNumber = document.getElementById('card').value;
    const pin = document.getElementById('pin').value;
    const amount = document.getElementById('amount').value;
    const atmId = document.getElementById('atm').value;

    const data = {
        cardNumber: cardNumber,
        pin: pin,
        amount: amount,
        atmId: atmId
    };



    fetch('http://localhost:5230/api/Transaction/Withdraw', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => response.text().then(text => {
            if (!response.ok) {
                let errorMessage = 'Unknown error';
                try {
                    const errorData = JSON.parse(text);
                    errorMessage = errorData.message || errorMessage;
                } catch (e) {
                    console.error('Error parsing response as JSON:', text);
                }
                throw new Error(errorMessage);
            }
            return text;
        }))
        .then(data => {
            console.log('Success:', data);
            alert('Withdrawal successful!');
        })
        .catch((error) => {
            console.error('Error:', error);
            alert(`Withdrawal failed: ${error.message}`);
        });


});
