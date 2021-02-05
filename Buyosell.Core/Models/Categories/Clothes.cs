namespace Buyosell.Core.Models.Categories
{
    class Clothes : Category
    {
        public Clothes()
        {
            base.Name = "Clothes";
        }

        public string ClothesBrand { get; set; }
        public bool ClothesType { get; set; }
        public string ClothesColor { get; set; }
        public string ClothesSize { get; set; }
    }
}