using ContactsCA.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsCA.services
{
    public class MenuManager
    {
        public List<Contacts> contacts = new List<Contacts>();
        public FileServices file = new FileServices();

        public string FilePath { get; set; } = null!;

        //     public Family? GetByFirstName(string FirstName)
        //     {
        //return contacts.SingleOrDefault(x => x.FirstName.Equals(FirstName));
        //     }

        public void WelcomeMenu()
        {
            Console.Clear();
            Console.WriteLine("MANAGE MENU" +
            "\n 1. Register a new contact" +
            "\n 2. Show all contacts" +
            "\n 3. Show a specific contact" +
            "\n 4. Delete a specific contact" +
            "\n Please chose an alternative.");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Option1();
                    break;

                case "2":
                    Option2();
                    break;

                case "3":
                    Option3();
                    break;

                case "4":
                    Option4();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Something went wrong, please press x to go back to Main Menu or press 5 to quit.");
                    break;
            }
        }


        private void Option1()
        {
            Console.Clear();
            Console.WriteLine("Please create a new contact. Want to go back to Main Menu? Press x.");

            Contacts contact = new Contacts();

            Console.WriteLine("Enter first name: ");
            contact.FirstName = Console.ReadLine() ?? "";

            Console.WriteLine("Enter last name: ");
            contact.LastName = Console.ReadLine() ?? "";

            Console.WriteLine("Enter phonenumber: ");
            try
            {
                contact.PhoneNumber = Convert.ToInt32(Console.ReadLine() ?? "");
            }
            catch
            {
                Console.WriteLine("Please enter a phonenumber with ONLY numbers");
                contact.PhoneNumber = Convert.ToInt32(Console.ReadLine() ?? "");
            }

            Console.WriteLine("Enter address: (ex. Varbergsvägen 53A 51161 Skene)");
            contact.Adress = Console.ReadLine() ?? "";

            Console.WriteLine("Enter emailadress: ");
            contact.Email = Console.ReadLine() ?? "";

            contacts.Add(contact);
            file.Save(FilePath, JsonConvert.SerializeObject(contacts));
        }

        private void Option2()
        {
            var contacts = JsonConvert.DeserializeObject<List<Contacts>>(file.Read(FilePath));

            Console.Clear();

            Console.WriteLine("All contacts: ");

            if (contacts != null && contacts.Count > 0)
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}>");
                }

            Console.ReadKey();
        }

        private void Option3()
        {
            //var oneContact = JsonConvert.DeserializeObject<List<Family>>(file.Read(FilePath));
            Console.Clear();

            Console.WriteLine("Enter the name of the contact that you wish to show: ");
            string? inputName = Console.ReadLine();

            var contact = contacts.FirstOrDefault(x => x.FirstName == inputName);
            if (contact != null)
                Console.WriteLine(contact.FirstName +
                    "/n" + contact.LastName +
                    "/n" + contact.PhoneNumber +
                    "/n" + contact.Adress +
                    "/n" + contact.Email);

            Console.ReadKey();

            //for (int i = 0; i < contacts.Count; i++)
            //{
            //	if(contacts[i].FirstName == inputName)
            //	{
            //		Console.WriteLine(contacts[i].FirstName);
            //	}
            //}

            //var result = contacts.Where(inputName => inputName == inputName).SingleOrDefault();

            //var findindex = contacts.FindIndex(contacts => contacts.FirstName == inputName);

            //var findC = contacts.FirstOrDefault(x => x.FirstName == inputName);

            //        if (inputName != null)
            //foreach (var contact in contacts)
            //{
            //	var findC = contacts.FirstOrDefault(x => x.FirstName == inputName);
            //	Console.WriteLine(findC);
            //	//Console.WriteLine($"{contact.FirstName}");

            //}

            //var oneC = contacts.ElementAt(oneContact);
            //var oneC = contacts[inputName];

            //         if (inputName != null && oneContact.Count > 0)
            //{
            //             var specificContact = oneContact.Where < x => x.ID >
            //         }

            //foreach (var contacts in contacts)
            //{
            //	Console.WriteLine(contacts);
            //}


            //var savedfiles = file.Read(FilePath);
            //var contacts = JsonConvert.DeserializeObject<List<IFamily>>(savedfiles);
            //var result = new Family();

            //foreach (var contact in contacts)
            //{
            //	if (contact.ID == ID)
            //	{
            //		result = (Family)contact;
            //		break;
            //	}
            //}
            //return;

        }

        private void Option4()
        {
            //var items = JsonConvert.DeserializeObject<List<Family>>(file.Read(FilePath));

            Console.WriteLine("Enter the name of the contact that you wish to delete: ");
            string input = Console.ReadLine();

            var contact = contacts.Where(x => x.FirstName == input);
            if (contact != null)
                //contacts.RemoveAt(contact);
                Console.WriteLine("Contact is deleted.");

            Console.ReadKey();

            //var response = contacts.Find(input => input.ID == input.ID);

            //contacts = contacts.Where(input => input.ID != input.ID).ToList();

            //if (input != null)
            //{
            //    contacts.RemoveAt(input);

            //	Console.WriteLine("Contact is removed.");
            //}

            //for (int i = 0; i < contacts.Count; i++ )
            //{
            //	if (contacts[i].Equals(input))
            //	{
            //		contacts.RemoveAt(i);
            //	}
            //}

            Console.ReadKey();
        }
    }
}
