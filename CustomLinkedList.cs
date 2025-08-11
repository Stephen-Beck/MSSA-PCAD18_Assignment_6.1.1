namespace Assignment_6._1._1
{
    public class Node
    {
        public House House { get; set; }
        public Node Next { get; set; }

        public Node(House house)
        {
            House = house;
            Next = null;
        }
    }

    public class CustomLinkedList
    {
        private Node head;
        private Node tail;
        private int size;
        public int Size { get { return size; } }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void AddLast(House house)
        {
            Node newNode = new Node(house);

            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                tail.Next = newNode;
            }

            tail = newNode;
            size++;
        }

        public House Search(int houseNumber)
        {
            if (size == 0)
            {
                Console.WriteLine("\nThere are no houses in the list.");
                return null;
            }

            Node house = head;

            while (house != null)
            {
                if (house.House.HouseNumber == houseNumber)
                    return house.House;

                house = house.Next;
            }

            if (size > 0) Console.WriteLine("\nHouse could not be found.");
            return null;
        }

        public void Display(House house)
        {
            if (house != null)
            {
                Console.WriteLine($"\nHouse Number: {house.HouseNumber}");
                Console.WriteLine($"     Address: {house.Address}");
                Console.WriteLine($"  House Type: {house.Type}\n");
            }
        }
    }
}
