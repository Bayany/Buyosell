using System;
using Buyosell.Core.Models;
using Buyosell.Core.Models.Categories;


namespace Buyosell.Api.Resources.Categories
{
    public class CarAdResource : IAdResource
    {
        public Car Category { get; set; }
    }
}