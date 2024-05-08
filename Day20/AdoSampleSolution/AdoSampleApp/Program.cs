

using AdoSampleApp.Model;

namespace AdoSampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ado_test_dbContext dbContext = new ado_test_dbContext();
            Person person = new Person();
            person.Id = 1;
            person.FirstName = "Bhavan Kumar";
            person.LastName = "Velladurai";
            person.Age = 21;
            dbContext.Persons.Add(person);
            dbContext.SaveChanges();
            Console.WriteLine("person added");
        }
    }
}
