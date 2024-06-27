using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private string m_MenuItemTitle;
        private int m_MenuItemIndex;
        private readonly List<MenuItem> r_SubMenuItems;
        private MenuItem m_ParentMenuItem;
        private readonly bool r_HasParentMenuItem;

        public MenuItem(string i_menuItemTitle, MenuItem i_ParentMenuItem = null)
        {
            this.m_MenuItemTitle = i_menuItemTitle;
            this.m_ParentMenuItem = i_ParentMenuItem;
            this.r_HasParentMenuItem = this.m_ParentMenuItem != null;
            this.r_SubMenuItems = new List<MenuItem>();
        }

        public string MenuItemTitle
        {
            get
            {
                return this.m_MenuItemTitle;
            }
            set
            {
                this.m_MenuItemTitle = value;
            }
        }

        public int MenuItemIndex
        {
            get
            {
                return this.m_MenuItemIndex;
            }
            set
            {
                this.m_MenuItemIndex = value;
            }
        }

        public List<MenuItem> SubMenuItems
        {
            get
            {
                return this.r_SubMenuItems;
            }
        }

        public void AddSubMenuItem(MenuItem i_SubMenuItem)
        {
            i_SubMenuItem.MenuItemIndex = this.SubMenuItems.Count;
            this.r_SubMenuItems.Add(i_SubMenuItem);
        }

        public void AddBackOrExitMenuItem()
        {
            string backOrExit = this.checkIfMainMenu();
            MenuItem backOrExitMenuItem = new MenuItem(backOrExit, this);
            
            this.AddSubMenuItem(backOrExitMenuItem);
        }

        internal void Show()
        {
            int chosenInputMenuItem;
            string divider = "- - - - - - - - - - - - - - - - - - - - - - -";
            string backOrExit = this.checkIfMainMenu();
            string menuSelectionMessage;
            string menuItemTitle = string.Format("**{0}**", this.m_MenuItemTitle);
            string invalidInputMessage;
            MenuItem chosenMenuItem;

            if (this.r_SubMenuItems.Count != 0)
            {
                Console.WriteLine(menuItemTitle);
                Console.WriteLine(divider);
                this.printSubMenuItems();
                Console.WriteLine(divider);
                menuSelectionMessage = string.Format("Enter your request: (1 to {0} or press 0 to {1}).", r_SubMenuItems.Count - 1, backOrExit);
                Console.WriteLine(menuSelectionMessage);
                chosenInputMenuItem = parseValidUserInput();
                Console.Clear();
                if (chosenInputMenuItem != 0)
                {
                    chosenMenuItem = this.SubMenuItems[chosenInputMenuItem];
                    chosenMenuItem.Show();
                }
                else
                {
                    this.m_ParentMenuItem?.Show();
                }
            }
            else if (!(this is MenuAction))
            {
                Console.WriteLine(divider);
                menuSelectionMessage = string.Format("Press 0 to {0}.", backOrExit);
                Console.WriteLine(menuSelectionMessage);
                chosenInputMenuItem = parseValidUserInput();
                while (chosenInputMenuItem != 0)
                {
                    invalidInputMessage = string.Format("Invalid input. Please press 0 to {0}.", backOrExit);
                    Console.WriteLine(invalidInputMessage);
                    Console.Clear();
                    chosenInputMenuItem = parseValidUserInput();
                }
            }
            else
            {
                chosenMenuItem = this;
                ((MenuAction)chosenMenuItem)?.OnPreformAction();
                Console.Write(Environment.NewLine);
                this.m_ParentMenuItem.Show();
            }
        }

        private string checkIfMainMenu()
        {
            return r_HasParentMenuItem ? "Back" : "Exit";
        }

        private void printSubMenuItems()
        {
            string lineToPrint;

            foreach (MenuItem subMenuItem in this.r_SubMenuItems)
            {
                if (subMenuItem.m_MenuItemIndex != 0)
                {
                    lineToPrint = string.Format("{0} -> {1}", subMenuItem.MenuItemIndex, subMenuItem.MenuItemTitle);
                    Console.WriteLine(lineToPrint);
                }
            }

            if (this.r_SubMenuItems.Count > 0)
            {
                lineToPrint = string.Format("0 -> {0}", this.checkIfMainMenu());
                Console.WriteLine(lineToPrint);
            }
        }

        private int parseValidUserInput()
        {
            string userInput = Console.ReadLine();
            bool userInputIsValidInteger = int.TryParse(userInput, out int userInputAsInteger);
            bool userInputIsInRange = (userInputAsInteger >= 0) && (userInputAsInteger <= this.r_SubMenuItems.Count - 1);
            
            while (!userInputIsValidInteger || !userInputIsInRange)
            {
                Console.WriteLine("Invalid Input. Please choose a number between 0 and {0} from the options above:", this.r_SubMenuItems.Count - 1);
                userInput = Console.ReadLine();
                userInputIsValidInteger = int.TryParse(userInput, out userInputAsInteger);
                userInputIsInRange = (userInputAsInteger >= 0) && (userInputAsInteger <= this.r_SubMenuItems.Count - 1);
            }

            return userInputAsInteger;
        }
    }
}
