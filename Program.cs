/*
Implement a single linked list with each node representing a house. 
Add data in it like house number, brief address, type of house (like Ranch, Colonial, etc). 
Each house (node) will be linked to next.
Allow the user to search a house by its number and then display the details.
Can be a WinForms or Console app.
*/

using System.ComponentModel.DataAnnotations;

namespace Assignment_6._1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList customList = new();
            
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"What would you like to do?");
                Console.WriteLine($"1. Add house");
                Console.WriteLine($"2. Display house information");
                Console.WriteLine($"3. Exit");

                bool validEntry = false;
                while (!validEntry)
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            House newHouse = House.GenerateHouse();
                            customList.AddLast(newHouse);
                            customList.Display(newHouse);
                            validEntry = true;
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            int houseNumber;
                            Console.Write("\nEnter a house number to search for: ");
                            while (!int.TryParse(Console.ReadLine().Trim(), out houseNumber) || houseNumber < 1)
                            {
                                Console.Write("House number must be a positive integer value greater than zero! Try again: ");
                            }
                            customList.Display(customList.Search(houseNumber));
                            validEntry = true;
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            validEntry = true;
                            exit = true;
                            break;
                    }

                    if (!exit)
                    {
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}