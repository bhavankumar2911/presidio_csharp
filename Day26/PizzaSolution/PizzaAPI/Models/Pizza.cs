namespace PizzaAPI.Models
{
    public enum Size
    {
        Small,
        Regular,
        Large
    }

    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double BasePrice { get; set; }

        public int Stock { get; set; }

        public Size Size { get; set; }
    }
}
