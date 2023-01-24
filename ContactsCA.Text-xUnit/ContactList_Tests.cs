using ContactsCA.models;
using ContactsCA.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsCA.Text_xUnit
{
    public class ContactList_Tests
    {
        private MenuManager contactbook;
        Contacts contact;

        public ContactList_Tests()
        {
            contactbook = new MenuManager();
            contact = new Contacts();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            contactbook.contacts.Add(contact);
            contactbook.contacts.Add(contact);

            Assert.Equal(2, contactbook.contacts.Count);
        }


        [Fact]
        public void Should_Remove_Contact_From_List()
        { 
            contactbook.contacts.Add(contact);
            contactbook.contacts.Add(contact);

            contactbook.contacts.Remove(contact);

            Assert.Single(contactbook.contacts);
        }
    }
}
