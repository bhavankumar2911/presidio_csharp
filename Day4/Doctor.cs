namespace Day4
{
    internal class Doctor
    {
        /// <summary>
        /// Ask user for a number until he enters a valid number
        /// </summary>
        /// <param name="ErrorMessage">Error message that should be shown to the user when invalid input is given</param>
        /// <returns>Returns the number given by the user</returns>
        internal static float GetNumberFromUserUntilItIsValid(string ErrorMessage = "Enter a valid number again!!")
        {
            float number;

            while (!float.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(ErrorMessage);
            }

            return number;
        }

        /// <summary>
        /// Get a string from the user. If no string is given, return an empty string
        /// </summary>
        /// <returns>Returns the string entered by the user</returns>
        static string GetStringFromUser()
        {
            return Console.ReadLine() ?? "";
        }

        /// <summary>
        /// Checks if the given word contains only alphabets and whitespaces
        /// </summary>
        /// <param name="word">Word to be checked for alphabets and whitespaces</param>
        /// <returns>Returns true or false</returns>
        bool ContainsOnlyAlphabetsAndSpace(string word)
        {
            foreach (char letter in word)
            {
                if (!char.IsLetter(letter) && !char.IsWhiteSpace(letter))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Ask user to enter a name until it is valid
        /// </summary>
        /// <returns>Returns the name entered by the user</returns>
        string GetValidName()
        {
            while (true)
            {
                string name = GetStringFromUser();

                if (!string.IsNullOrEmpty(name) && ContainsOnlyAlphabetsAndSpace(name)) { return name; }

                Console.WriteLine("Enter a valid name: ");
            }
        }

        /// <summary>
        /// Asks user to enter a string until it is not empty
        /// </summary>
        /// <param name="errorMessage">Custom error message to be shown to the user for empty string inputs</param>
        /// <returns>Returns the string entered by the user.</returns>
        internal static string GetStringFromUserUntilItIsEmpty(string errorMessage = "Enter a non empty string again to continue.")
        {
            while (true)
            {
                string str = GetStringFromUser();

                if (!string.IsNullOrEmpty(str)) { return str; }

                Console.WriteLine(errorMessage);
            }
        }

        /// <summary>
        /// Get Doctor details from user through console.
        /// </summary>
        /// <returns>Returns the reference to the Doctor object</returns>
        internal Doctor GetDoctorDetailsFromUser ()
        {
            Doctor doctor = new Doctor();

            Console.Write("Enter doctor's name: ");
            doctor.Name = GetValidName();

            Console.Write("Enter doctor's age: ");
            doctor.Age = GetNumberFromUserUntilItIsValid("Age must be number. Enter Again");

            Console.Write("Enter doctor's experience: ");
            doctor.Experience = GetNumberFromUserUntilItIsValid("Experience must be number. Enter Again");

            Console.Write("Enter doctor's Qualification: ");
            doctor.Qualification = GetStringFromUserUntilItIsEmpty("Qualification is required. Kindly enter again.");

            Console.Write("Enter doctor's Speciality: ");
            doctor.Speciality = GetStringFromUserUntilItIsEmpty("Speciality is required. Kindly enter again.");

            return doctor;
        }

        /// <summary>
        /// Print details of the doctor
        /// </summary>
        internal void PrintDoctorDetails ()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Experience: {Experience}");
            Console.WriteLine($"Qualification: {Qualification}");
            Console.WriteLine($"Speciality: {Speciality}");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("");
        }

        /// <summary>
        /// Doctor has the following properties
        /// 1. Id
        /// 2. Name
        /// 3. Age
        /// 4. Experience
        /// 5. Qualification
        /// 6. Speciality
        /// 7. List of Doctors
        /// </summary>
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Age { get; set; }
        public float Experience { get; set; }
        public string? Qualification { get; set; }
        public string? Speciality { get; set; }

    }
}
