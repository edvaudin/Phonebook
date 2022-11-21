﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    internal class UserInput
    {
        public static string GetUserOption()
        {
            string input = Console.ReadLine();
            while (!Validator.IsValidOption(input))
            {
                Console.Write("\nThis is not a valid input. Please enter one of the above options: ");
                input = Console.ReadLine();
            }
            return input;
        }

        public static string GetUserUpdateOption()
        {
            string input = Console.ReadLine();
            while (!Validator.IsValidUpdateOption(input))
            {
                Console.Write("\nThis is not a valid input. Please enter one of the above options: ");
                input = Console.ReadLine();
            }
            return input;
        }

        public static string GetName()
        {
            string input = Console.ReadLine();
            while (!Validator.IsValidStringInput(input, 100))
            {
                Console.Write("\nThis is not a valid name. Try again.");
                input = Console.ReadLine();
            }
            return input;
        }

        internal static string GetPhoneNumber()
        {
            string input = Console.ReadLine();
            while (!Validator.IsValidPhoneNumber(input))
            {
                Console.Write("\nThis is not a valid phone number. Please ensure your input only contains digits and try again.");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
