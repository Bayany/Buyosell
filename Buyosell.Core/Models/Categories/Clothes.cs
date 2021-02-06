namespace Buyosell.Core.Models.Categories
{
    public class Clothes : Category
    {
        public Clothes()
        {
            base.Name = "Clothes";
        }

        public string Brand { get; set; }
        public bool Type { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}