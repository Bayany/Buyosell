using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buyosell.Api.Resources
{
    public class UserResource
    {
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

    }
}