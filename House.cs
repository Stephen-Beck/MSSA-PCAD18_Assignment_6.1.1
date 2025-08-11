using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6._1._1
{
    public class House
    {
        private static HashSet<int> houseNumbers = new();
        public enum HouseType { Unknown, Colonial, Ranch, Victorian, Other}
        
        public int HouseNumber { get; set; }
        public string Address { get; set; }
        public HouseType Type { get; set; }

        House(int houseNumber, string address, HouseType type = HouseType.Unknown)
        {
            HouseNumber = houseNumber;
            Address = address;
            Type = type;
        }

        public static House GenerateHouse()
        {
            string userInput;
            int houseNumber = -1;

            Console.Write("\nEnter house number: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine().Trim(), out houseNumber))
                {
                    if (houseNumber > 0)
                    {
                        if (houseNumbers.Contains(houseNumber))
                            Console.Write("House number already exists in database! Enter house number: ");
                        else
                            break;
                    }
                    else
                        Console.Write("House number must be greater than zero! Enter house number: ");
                }
                else
                    Console.Write("Invalid house number. Try again. ");
            }

            Console.Write("\nEnter address: ");
            string address = Console.ReadLine().Trim();

            var type = HouseType.Unknown;
            Console.WriteLine("\nEnter house type:");
            Console.WriteLine("1. Unknown");
            Console.WriteLine("2. Colonial");
            Console.WriteLine("3. Ranch");
            Console.WriteLine("4. Victorian");
            Console.WriteLine("5. Other\n");
            bool validEntry = false;
            while (!validEntry)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        // type is already set to Unknown
                        validEntry = true; 
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        type = HouseType.Colonial;
                        validEntry = true;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        type = HouseType.Ranch;
                        validEntry = true;                        
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        type = HouseType.Victorian;
                        validEntry = true;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        type = HouseType.Other;
                        validEntry = true;
                        break;
                }
            }

            houseNumbers.Add(houseNumber);
            Console.WriteLine("House created!");
            return new House(houseNumber, address, type);
        }
    }
}
