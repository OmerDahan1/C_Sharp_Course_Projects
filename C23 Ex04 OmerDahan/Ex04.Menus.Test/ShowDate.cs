using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class ShowDate : IMenuAction
    {
        public void PreformAction()
        {
            string currentDateMessage = string.Format("Current date:    {0}", DateTime.Now.Date.ToShortDateString());
            
            Console.WriteLine(currentDateMessage);
        }
    }
}
