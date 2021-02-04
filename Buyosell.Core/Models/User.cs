using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buyosell.Core.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [ForeignKey("UserId")]
        public List<Ad> PublishedAds { get; set; }
        public List<Ad> Wishlist { get; set; }


    }
}