using System.Globalization;

namespace WordGame 
{   class Program
    {
        static void Main() {
            SetLanguage();
            Game game = new Game();
            game.Start();
        }

        private static void SetLanguage()
        {
            Console.WriteLine("Choose your language:");
            Console.WriteLine("1. Russian");
            Console.WriteLine("2. English");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                    break;
                case "2":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    break;
                default:
                    Console.WriteLine("Wrong choice, setting default language - English.");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                    break;
            }
        }
    }
}
