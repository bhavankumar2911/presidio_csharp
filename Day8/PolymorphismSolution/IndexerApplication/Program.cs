namespace IndexerApplication
{
    class Person
    {

        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Company
    {
        Person[] Persons = new Person[5];

        public Company()
        {
            Persons[0] = new Person("Bhavan", 21);
            Persons[1] = new Person("John", 21);
            Persons[2] = new Person("Jane", 23);
        }

        public int this[string name]
        {
            get
            {
                for (int i = 0; i < Persons.Length; i++)
                {
                    if (Persons[i].Name == name) return Persons[i].Age;
                }

                return -1;
            }
        }

        public string this[int age]
        {
            get
            {
                for (int i = 0; i < Persons.Length; i++)
                {
                    if (Persons[i].Age == age) return Persons[i].Name;
                }

                return "";
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            Console.WriteLine(company["Bhavan"]);
            Console.WriteLine(company[23]);
        }
    }
}
