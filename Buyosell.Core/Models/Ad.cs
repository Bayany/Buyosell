using System;
using System.ComponentModel;

namespace Buyosell.Core.Models
{
    public enum City
    {
        [Description("Tehran")]
        Tehran,

        [Description("Isfahan")]
        Isfahan,

        [Description("Mashhad")]
        Mashhad,

        [Description("Shiraz")]
        Shiraz
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
        public virtual Category Category { get; set; }
    }
}