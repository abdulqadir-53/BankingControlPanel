using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Principal;

namespace BankingControlPanel.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public string? ProfilePhoto { get; set; } // Make it nullable if not required
        public string MobileNumber { get; set; }
        public string Sex { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}