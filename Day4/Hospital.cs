using System.Numerics;

namespace Day4
{
    internal class Hospital
    {
        public Doctor[] Doctors { get; set; } = new Doctor[10];
        public int NumberOfDoctorsInHospital { get; set; } = 0;

        /// <summary>
        /// Adds a new Doctor to the list
        /// </summary>
        /// <param name="doctor">Reference to the new doctor object</param>
        void AddNewDoctor (Doctor doctor)
        {
            Doctors[NumberOfDoctorsInHospital++] = doctor;
        }

        /// <summary>
        /// Checks if there are any doctors available for printing
        /// </summary>
        /// <returns>Returns true if doctors are present or vice versa</returns>
        bool CheckIfAnyDoctorsAvailable()
        {
            if (Doctors == null || NumberOfDoctorsInHospital == 0)
            {
                Console.WriteLine("No doctors are available. Kindly add some!");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Print all the details of all the doctors
        /// </summary>
        void PrintAllDoctors()
        {
            if (!CheckIfAnyDoctorsAvailable()) return;

            for (int i = 0; i < NumberOfDoctorsInHospital; i++)
            {
                Doctors[i].PrintDoctorDetails();
            }
        }

        /// <summary>
        /// Print only the details of the doctors for the speciality given by the user
        /// </summary>
        /// <param name="speciality"></param>
        void PrintOnlyTheDoctorsOfTheSpecializationGivenByUser(string speciality)
        {
            if (!CheckIfAnyDoctorsAvailable()) return;

            int doctorsCount = 0; // doctors count for a specific speciality

            for (int i = 0; i < NumberOfDoctorsInHospital; i++)
            {
                Doctor doctor = Doctors[i];

                if (doctor.Speciality == speciality)
                {
                    doctorsCount++;
                    doctor.PrintDoctorDetails();
                }
            }

            if (doctorsCount == 0) Console.WriteLine($"Unfortunately no doctors are in this specialization({speciality})");
        }

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Choose the operation");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Show all doctors");
                Console.WriteLine("3. Filter doctors by speciality");
                Console.WriteLine("4. Exit application");

                float operation = Doctor.GetNumberFromUserUntilItIsValid("Operation must be a number. Kindly enter again");

                Doctor doctor = new Doctor();
                Hospital hospital = new Hospital();

                switch (operation)
                {
                    case 1:
                        Doctor newDoctor = doctor.GetDoctorDetailsFromUser();
                        hospital.AddNewDoctor(newDoctor);
                        break;
                    case 2:
                        hospital.PrintAllDoctors();
                        break;
                    case 3:
                        Console.Write("Enter the speciality: ");
                        string speciality = Doctor.GetStringFromUserUntilItIsEmpty("Speciality is required. Kindly enter again.");
                        hospital.PrintOnlyTheDoctorsOfTheSpecializationGivenByUser(speciality);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Kindly enter a valid operation");
                        break;
                }

            } while (true);
        }
    }
}
