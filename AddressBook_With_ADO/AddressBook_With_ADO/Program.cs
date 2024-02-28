using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_With_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n1. Add new contact.");
                Console.WriteLine("2. Edit Contact details.");
                Console.WriteLine("3. Delete Contact.");
                Console.WriteLine("4. Show All Contacts.");
                Console.WriteLine("5. Exit.");

                Console.Write("Enter Choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1: // add
                        BookOperations.AddNewUser();
                        break;

                    case 2: // edit
                        BookOperations.EditContactDetails();
                        break;

                    case 3: // delete
                        BookOperations.DeleteContact();
                        break;

                    case 4: // print
                        BookOperations.PrintData();
                        break;

                    case 5: // exit
                        Console.WriteLine("\nExiting Program. . .");
                        break;

                    default: // invalid choice
                        Console.WriteLine("\nInvalid Choice! ! !");
                        break;
                }
            } while (choice != 5);
        }
    }
}
