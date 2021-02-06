namespace Buyosell.Core.Models.Categories
{
    public class Car : Category
    {
        public Car()
        {
            base.Name = "Car";
        }

        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PYear { get; set; }
    }
}