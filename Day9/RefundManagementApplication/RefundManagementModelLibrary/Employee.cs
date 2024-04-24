namespace RefundManagementModelLibrary
{
    public enum Gender
    {
        Male,
        Female,
        PreferNotToSay
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public float Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Employee()
        {
        }

        public Employee(string name, Gender gender, float age, string email, string password)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Email = email;
            Password = password;
        }

        public string GetGenderInString ()
        {
            switch (Gender)
            {
                case Gender.Male:
                    return "Male";
                case Gender.Female:
                    return "Female";
                case Gender.PreferNotToSay:
                    return "Not disclosed";
                default:
                    return "NA";
            }
        }
    }
}
