const userName = document.getElementById("name");
const nameFeedback = document.getElementById("nameFeedback");

const email = document.getElementById("email");
const emailFeedback = document.getElementById("emailFeedback");

const phone = document.getElementById("phone");
const phoneFeedback = document.getElementById("phoneFeedback");

const dob = document.getElementById("dob");
const dobFeedback = document.getElementById("dobFeedback");

const age = document.getElementById("age");

const male = document.getElementById("male");
const female = document.getElementById("female");
const genderFeedback = document.getElementById("genderFeedback");

const form = document.getElementsByTagName("form")[0];

const professionSelect = document.getElementById("profession-select");
const professionText = document.getElementById("profession-text");
const professionFeedback = document.getElementById("professionFeedback");

const alertMessage = document.getElementById("alert");

const showErrorMessage = (inputElement, errorElement, errorMessage) => {
  errorElement.innerText = errorMessage;
  inputElement.classList.add("is-invalid");
};

const showRequiredErrorMessage = (fieldName, inputElement, errorElement) => {
  return showErrorMessage(
    inputElement,
    errorElement,
    `${fieldName} cannot be empty.`
  );
};

const showValidStatus = (inputElement) => {
  inputElement.classList.remove("is-invalid");
  inputElement.classList.add("is-valid");
};

const calculateAge = (date) => {
  const dateSplitted = date.split("-");

  var diff_ms =
    Date.now() -
    new Date(
      dateSplitted[0],
      parseInt(dateSplitted[1]) - 1,
      dateSplitted[2]
    ).getTime();
  var age_dt = new Date(diff_ms);
  return Math.abs(age_dt.getUTCFullYear() - 1970);
};

// name validation
userName.addEventListener("keyup", (e) => {
  const value = e.target.value;
  const alphabetCheckRegex = /^[a-zA-Z ]*$/;

  if (!value) return showRequiredErrorMessage("Name", userName, nameFeedback);

  if (value.length < 3)
    return showErrorMessage(
      userName,
      nameFeedback,
      "Name must have atleast 3 characters."
    );

  if (!alphabetCheckRegex.test(value)) {
    return showErrorMessage(
      userName,
      nameFeedback,
      "Name can have only alphabets."
    );
  }

  return showValidStatus(userName);
});

// phone number validation
phone.addEventListener("keyup", (e) => {
  const value = e.target.value;
  const phoneFormatCheckRegex =
    /^[+]{1}(?:[0-9\-\\(\\)\\/.]\s?){6,15}[0-9]{1}$/;

  if (!value)
    return showRequiredErrorMessage("Phone number", phone, phoneFeedback);

  if (!phoneFormatCheckRegex.test(value)) {
    return showErrorMessage(
      phone,
      phoneFeedback,
      "Kindly enter a valid phone number with country code."
    );
  }

  return showValidStatus(phone);
});

// email validation
email.addEventListener("keyup", (e) => {
  const value = e.target.value;
  const emailFormatCheckRegex =
    /^[a-zA-Z0-9_.±]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$/;

  if (!value) return showRequiredErrorMessage("Email", email, emailFeedback);

  if (!emailFormatCheckRegex.test(value)) {
    return showErrorMessage(
      email,
      emailFeedback,
      "Kindly enter a valid email address."
    );
  }

  return showValidStatus(email);
});

// dob validation
dob.addEventListener("change", (e) => {
  const value = e.target.value;
  const dobFormatCheckRegex =
    /^(\d{4})-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$/;

  if (!value)
    return showRequiredErrorMessage("Date of birth", dob, dobFeedback);

  if (!dobFormatCheckRegex.test(value)) {
    age.value = "";
    return showErrorMessage(dob, dobFeedback, "Date of birth is not valid.");
  }

  age.value = calculateAge(value);
  return showValidStatus(dob);
});

// submit validation
form.addEventListener("submit", (e) => {
  e.preventDefault();

  if (!userName.value) showRequiredErrorMessage("Name", userName, nameFeedback);
  if (!email.value) showRequiredErrorMessage("Email", email, emailFeedback);
  if (!phone.value)
    showRequiredErrorMessage("Phone number", phone, nameFeedback);
  if (!dob.value) showRequiredErrorMessage("Date of birth", dob, dobFeedback);

  if (!male.checked && !female.checked)
    return genderFeedback.classList.remove("d-none");

  genderFeedback.classList.add("d-none");

  if (!professionSelect.value && !professionText.value) {
    professionFeedback.innerText = "Kindly select or enter a profession.";
    return professionFeedback.classList.remove("d-none");
  }

  if (professionSelect.value && professionText.value) {
    professionFeedback.innerText = "You cannot give multiple professions.";
    return professionFeedback.classList.remove("d-none");
  }

  professionFeedback.classList.add("d-none");
  alertMessage.classList.remove("d-none");
});
