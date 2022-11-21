using Microsoft.EntityFrameworkCore;
using Phonebook.DataAccess;
using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    internal class UserController
    {
        public static void ProcessInput(string userInput)
        {
            switch (userInput)
            {
                case "v":
                    ViewContacts();
                    break;
                case "a":
                    AddContact();
                    break;
                case "d":
                    DeleteContact();
                    break;
                case "u":
                    UpdateContact();
                    break;
                case "0":
                    Program.SetEndAppToTrue();
                    break;
                default:
                    break;
            }
        }

        private static void UpdateContact()
        {
            using var db = new ContactContext();
            Console.WriteLine("\nPlease enter the name of the contact for updating:");
            string name = UserInput.GetName();
            if (!Validator.IsNameInContacts(db, name))
            {
                Console.WriteLine($"\nWe could not find anyone called {name} in your contacts. Please try again.");
                UpdateContact();
            }
            else
            {
                Contact contact = db.Contacts.Where(c => c.Name == name).FirstOrDefault();
                Console.WriteLine($"\nWould you like to update {name}'s name or phone number? (Type 'n' or 'p')");
                string option = UserInput.GetUserUpdateOption();
                if (option == "n")
                {
                    Console.WriteLine("\nPlease enter the new name for this contact:");
                    string newName = UserInput.GetName();
                    contact.Name = newName;
                    db.SaveChanges();
                    Console.WriteLine($"\n{name}'s name has been updated to: {newName}");
                }
                else if (option == "p")
                {
                    Console.WriteLine("\nPlease enter the new phone number for this contact:");
                    string newNum = UserInput.GetPhoneNumber();
                    contact.PhoneNumber = newNum;
                    db.SaveChanges();
                    Console.WriteLine($"\n{name}'s phone number has been updated to: {newNum}");
                }
            }
        }

        private static void DeleteContact()
        {
            using var db = new ContactContext();
            Console.WriteLine("\nPlease enter the name of the contact for deletion:");
            string name = UserInput.GetName();
            if (!Validator.IsNameInContacts(db, name))
            {
                Console.WriteLine($"\nWe could not find anyone called {name} in your contacts. Please try again.");
                DeleteContact();
            }
            else
            {
                db.Remove(db.Contacts.Where(c => c.Name == name).FirstOrDefault());
                db.SaveChanges();
                Console.WriteLine($"\n{name} has been removed from your contacts.");
            }
        }



        private static void AddContact()
        {
            using var db = new ContactContext();
            Console.WriteLine("\nWhat is the name of your new contact?");
            string name = UserInput.GetName();
            if (Validator.IsNameInContacts(db, name))
            {
                Console.WriteLine($"\n{name} is already in your contacts, try updating their number instead.");
                return;
            }
            Console.WriteLine("\nWhat is the phone number of your new contact?");
            string phoneNumber = UserInput.GetPhoneNumber();
            db.Add(new Contact { Name = name, PhoneNumber = phoneNumber });
            db.SaveChanges();
            Console.WriteLine($"\n{name} has been added to your contacts.");
        }

        private static void ViewContacts()
        {
            using var db = new ContactContext();
            List<Contact> contacts = db.Contacts.OrderBy(x => x.Name).ToList();
            string output = string.Empty;
            foreach (var contact in contacts)
            {
                output += $"Name: {contact.Name} Phone Number: {contact.PhoneNumber}\n";
            }
            Console.WriteLine(output);
        }
    }
}
