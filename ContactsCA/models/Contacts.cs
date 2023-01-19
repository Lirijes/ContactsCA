using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsCA.models
{
    public interface IContacts
    {
        Guid ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int PhoneNumber { get; set; }
        string Adress { get; set; }
        string Email { get; set; }
    }

    public class Contacts : IContacts
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Adress { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string DisplayName => $"{FirstName} {LastName}";
    }
}
