const { JSDOM } = require("jsdom");
const fs = require("fs");
const path = require("path");

// Load the HTML content from index.html
const html = fs.readFileSync(path.resolve(__dirname, "./login.html"), "utf8");

let dom;
let document;
let loginForm;
let loginMessage;
let usernameInput;
let passwordInput;

beforeEach(() => {
  // Initialize jsdom
  dom = new JSDOM(html, { runScripts: "dangerously" });
  document = dom.window.document;

  const scriptElement = document.createElement("script");
  scriptElement.textContent = fs.readFileSync(
    path.resolve(__dirname, "./script.js"),
    "utf8"
  );
  document.body.appendChild(scriptElement);

  // Get elements from the DOM
  loginForm = document.getElementById("login-form");
  loginMessage = document.getElementById("login-message");
  usernameInput = document.getElementById("username");
  passwordInput = document.getElementById("password");
});

// Helper function
function submitForm(username, password) {
  usernameInput.value = username;
  passwordInput.value = password;
  loginForm.dispatchEvent(new dom.window.Event("submit"));
}

// Test cases
describe("Login Form", () => {
  it("should display login success message", () => {
    submitForm("user1", "password1");

    expect(loginMessage.textContent).toContain("Login successful");
    expect(loginMessage.style.color).toBe("green");
  });

  it("should display login error message for invalid credentials", () => {
    submitForm("invaliduser", "invalidpassword");

    expect(loginMessage.textContent).toContain("Invalid username or password");
    expect(loginMessage.style.color).toBe("red");
  });

  it("should clear input fields after form submission", () => {
    submitForm("user1", "password1");

    expect(usernameInput.value).toBe("");
    expect(passwordInput.value).toBe("");
  });
});
