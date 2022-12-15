namespace CarRental.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Menu();
        }


        static void Menu()
        {
            Console.Title = "Wypożyczalnia aut";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                Console.WriteLine("1 - Pokaż listę samochodów.");
                Console.WriteLine("2 - Wyszukaj samochód po roczniku.");
                Console.WriteLine("3 - Wyszukaj samochód po nazwie.");
                Console.WriteLine("4 - Wyszukaj samochód po dacie dostępności.");
                Console.WriteLine("5 - Wyszukaj samochód do wypożyczenia po nazwie.");
                Console.WriteLine("6 - Wyszukaj samochód po wyposażeniu.");
                Console.WriteLine("7 - Dodaj samochód.");
                Console.WriteLine("8 - Pokaż wypożyczenia.");
                Console.WriteLine("9 - Dodaj wypożeczenie.");
                Console.WriteLine("0 - Edytuj wypożyczenie.");
                Console.WriteLine("F1 - Edytuj dane samochodu.");
                ConsoleKeyInfo read = Console.ReadKey();
                switch(read.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear(); SearchCarByName();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.D8:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.D9:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.D0:
                        Console.Clear(); PlaceHOlder();
                        break;
                    case ConsoleKey.F1:
                        Console.Clear(); PlaceHOlder();
                        break;
                    default: break;
                }
            }
        }
        
        public static Car SearchCarByName()
        {
            Console.WriteLine("tak");
            Console.ReadKey();
            return null;
        }
        
        //Zastępstwo za przyszłe funkcje
        static void PlaceHOlder()
        {
            Console.WriteLine("PlaceHolder");
            Console.ReadKey();
        }
    }
}