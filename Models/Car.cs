namespace LuxCars.Models
{
    public class Car
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Engine { get; set; }
        public required string Color { get; set; }
        public required decimal Price_per_day {  get; set; }

    }
}
