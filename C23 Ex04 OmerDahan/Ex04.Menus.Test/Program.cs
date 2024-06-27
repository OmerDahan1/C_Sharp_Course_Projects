using Ex04.Menus.Interfaces;
using Ex04.Menus.Delegates;
using System;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            printInterfaceAndDelegate();
        }

        private static void printInterfaceAndDelegate() 
        {
            printInterface();
            printDelegate();
        }

        private static void printInterface()
        {
            Interfaces.MenuItem mainMenu = new Interfaces.MenuItem("Interfaces Main Menu", null);

            mainMenu.AddBackOrExitMenuItem();
            Interfaces.MenuItem showDateOrTime = new Interfaces.MenuItem(@"Show Date/Time", mainMenu);
            Interfaces.MenuItem versionAndCapitals = new Interfaces.MenuItem("Version and Capitals", mainMenu);
            showDateOrTime.AddBackOrExitMenuItem();
            Interfaces.MenuAction showDate = new Interfaces.MenuAction("Show Date", showDateOrTime);
            showDate.MenuActionInterface = new ShowDate();
            Interfaces.MenuAction showTime = new Interfaces.MenuAction("Show Time", showDateOrTime);
            showTime.MenuActionInterface = new ShowTime();
            versionAndCapitals.AddBackOrExitMenuItem();
            Interfaces.MenuAction showVersion = new Interfaces.MenuAction("Show Version", versionAndCapitals);
            showVersion.MenuActionInterface = new ShowVersion();
            Interfaces.MenuAction countCapitals = new Interfaces.MenuAction("Count Capitals", versionAndCapitals);
            countCapitals.MenuActionInterface = new CountCapitals();
            mainMenu.AddSubMenuItem(showDateOrTime);
            mainMenu.AddSubMenuItem(versionAndCapitals);
            showDateOrTime.AddSubMenuItem(showDate);
            showDateOrTime.AddSubMenuItem(showTime);
            versionAndCapitals.AddSubMenuItem(showVersion);
            versionAndCapitals.AddSubMenuItem(countCapitals);
            Interfaces.MainMenu mainMenuItem = new Interfaces.MainMenu(mainMenu);
            mainMenuItem.Show();
        }
        
        private static void printDelegate()
        {
            Delegates.MenuItem mainMenu = new Delegates.MenuItem("Delegates Main Menu", null);

            mainMenu.AddBackOrExitMenuItem();
            Delegates.MenuItem showDateOrTime = new Delegates.MenuItem(@"Show Date/Time", mainMenu);
            Delegates.MenuItem versionAndCapitals = new Delegates.MenuItem("Version and Capitals", mainMenu);
            showDateOrTime.AddBackOrExitMenuItem();
            versionAndCapitals.AddBackOrExitMenuItem();
            Delegates.MenuAction showDate = new Delegates.MenuAction("Show Date", showDateOrTime);
            showDate.PreformAction += showDate_PreformAction;
            Delegates.MenuAction showTime = new Delegates.MenuAction("Show Time", showDateOrTime);
            showTime.PreformAction += showTime_PreformAction;
            Delegates.MenuAction showVersion = new Delegates.MenuAction("Show Version", versionAndCapitals);
            showVersion.PreformAction += showVersion_PreformAction;
            Delegates.MenuAction countCapitals = new Delegates.MenuAction("Count Capitals", versionAndCapitals);
            countCapitals.PreformAction += countCapitals_PreformAction;
            mainMenu.AddSubMenuItem(showDateOrTime);
            mainMenu.AddSubMenuItem(versionAndCapitals);
            showDateOrTime.AddSubMenuItem(showDate);
            showDateOrTime.AddSubMenuItem(showTime);
            versionAndCapitals.AddSubMenuItem(showVersion);
            versionAndCapitals.AddSubMenuItem(countCapitals);
            Delegates.MainMenu mainMenuItem = new Delegates.MainMenu(mainMenu);
            mainMenuItem.Show();

        }

        private static void showDate_PreformAction() 
        {
            string currentDateMessage = string.Format("Current date:    {0}", DateTime.Now.Date.ToShortDateString());
            
            Console.WriteLine(currentDateMessage);
        }

        private static void showTime_PreformAction()
        {
            string currentDateMessage = string.Format("Current date:    {0}", DateTime.Now.ToString("HH:mm:ss"));
            
            Console.WriteLine(currentDateMessage);
        }

        private static void showVersion_PreformAction() 
        {
            Console.WriteLine("Version: 23.3.4.9835");
        }

        private static void countCapitals_PreformAction()
        {
            int numberOfCapitalLetters = 0;

            Console.WriteLine("Please enter your sentence:");
            string inputSentence = Console.ReadLine();
            foreach (char c in inputSentence)
            {
                if (char.IsUpper(c))
                {
                    numberOfCapitalLetters++;
                }
            }

            Console.WriteLine("There are {0} capitals in your sentence.", numberOfCapitalLetters);
        }
    }
}
