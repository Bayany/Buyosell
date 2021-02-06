using System;
using Buyosell.Core.Models;
using Buyosell.Core.Models.Categories;


namespace Buyosell.Api.Resources.Categories
{
    public class IAdResource
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public City City { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}