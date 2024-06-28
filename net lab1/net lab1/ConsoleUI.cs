using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab1
{
    internal class ConsoleUI
    {
        public static int userChoice()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Choose your request:" +
     "\n0. Finish program." +
     "\n1. Get students whose name contains \"Joe\"." +
     "\n2. Get commandants older than 50 years." +
     "\n3. Get hostels with more than 300 rooms." +
     "\n4. Get settlements after January 1, 2016." +
     "\n5. Get students from the \"FICT\" faculty." +
     "\n6. Get commandants from hostels with less than 300 rooms." +
     "\n7. Get commandants and hostels." +
     "\n8. Get settlements with a duration less than 30 days." +
     "\n9. Get students who settled after January 1, 2016." +
     "\n10. Get commandants with names containing the letter \"a\"." +
     "\n11. Get hostels with more female students than male students." +
     "\n12. Get settlements overlapping December 1, 2015, to January 1, 2016." +
     "\n13. Get students from hostels with even IDs." +
     "\n14. Get experienced commandants with more than 10 years of experience." +
     "\n15. Get hostels with the letter \"o\" in their address." +
     "\n16. Get settlements with a duration of exactly 30 days." +
     "\n17. Get students along with their commandants." +
     "\n18. Get the average age of students in each hostel." +
     "\n19. Get names of students in hostels with capacities greater than 200." +
     "\n20. Get commandants and their managed hostels, sorted by the number of settled students in each hostel.");

                Console.ForegroundColor = ConsoleColor.White;

                bool valueIsValid = false;
                int choice = -1;
                while (!valueIsValid)
                {
                    Console.WriteLine("Enter your Choice:");
                    choice = int.Parse(Console.ReadLine());
                    if (choice < 0 || choice > 20)
                    {
                        Console.WriteLine("Value is i ncorrect, Try again.");
                        valueIsValid = false;
                    }
                    else {valueIsValid=true; return choice; }

                }
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine("VALUE IS INCORRECT");
                return -1;
            }
        }
    }
}
