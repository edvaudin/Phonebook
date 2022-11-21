using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    internal class UserMenu
    {
        public static void DisplayOptionsMenu()
        {
            Console.WriteLine("\nChoose an action from the following list:\n");
            Console.WriteLine("\tv - View your contacts");
            Console.WriteLine("\ta - Add a new contact");
            Console.WriteLine("\td - Delete a contact");
            Console.WriteLine("\tu - Update a contact");
            Console.WriteLine("\t0 - Quit this application");
            Console.Write("\nYour option? ");
        }

        public static void DisplayTitle()
        {
            Console.WriteLine("Your Contacts\r");
            Console.WriteLine("-------------\n");
        }
    }
}
