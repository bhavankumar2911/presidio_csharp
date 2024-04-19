namespace StructureApplication
{
    struct Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person()
            {
                Id = 1,
                Name = "Bhavan",
            };

            Person person2 = person1;

            person1.Name = "Bhavan Kumar";

            Console.WriteLine($"name in person1 {person1.Name}");
            Console.WriteLine($"name in person2 {person2.Name}");
        }
    }
}
