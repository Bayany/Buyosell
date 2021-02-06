using System;
using Buyosell.Core.Models;
using Buyosell.Core.Models.Categories;


namespace Buyosell.Api.Resources.Categories
{
    public class ClothesAdResource: IAdResource
    {
        public Clothes Category { get; set; }
    }
}