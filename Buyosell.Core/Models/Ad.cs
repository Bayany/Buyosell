using System;


namespace Buyosell.Core.Models
{
    public enum City
    {
        Tehran, Isfahan, Mashhad, Shiraz
    }
    public class Ad
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public City City { get; set; }
        public DateTime PublishedDate { get; set; }
        public Category Category { get; set; }
    }
}