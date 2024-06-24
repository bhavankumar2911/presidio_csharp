document.addEventListener("DOMContentLoaded", function () {
  // Dummy users array with username and password
  var users = [
    { username: "user1", password: "password1" },
    { username: "user2", password: "password2" },
    { username: "user3", password: "password3" },
    { username: "user4", password: "password4" },
    { username: "user5", password: "password5" },
  ];

  // Selecting elements from the DOM
  var loginForm = document.getElementById("login-form");
  var loginMessage = document.getElementById("login-message");
  var usernameInput = document.getElementById("username");
  var passwordInput = document.getElementById("password");

  // Event listener for form submission
  loginForm.addEventListener("submit", function (event) {
    event.preventDefault();

    // Get username and password input values
    var username = usernameInput.value.trim();
    var password = passwordInput.value.trim();

    // Check if username and password match a user in the array
    var authenticatedUser = users.find(function (user) {
      return user.username === username && user.password === password;
    });

    // Display login status
    if (authenticatedUser) {
      loginMessage.textContent = "Login successful. Welcome, " + username + "!";
      loginMessage.style.color = "green"; // Green color for success message
    } else {
      loginMessage.textContent =
        "Invalid username or password. Please try again.";
      loginMessage.style.color = "red"; // Red color for error message
    }

    // Clear input fields after submission
    usernameInput.value = "";
    passwordInput.value = "";
  });
});
