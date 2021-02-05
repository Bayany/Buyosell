using Buyosell.Core.Models;

namespace Buyosell.Core.Models.Categories
{
    class Car : Category
    {
        public string CarManufacturer {get; set;}
        public string CarModel {get; set;}
        public string CarColor {get; set;}
        public string  CarPYear {get; set;}
    }
}