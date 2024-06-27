using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class ShowTime : IMenuAction
    {
        public void PreformAction()
        {
            string currentDateMessage = string.Format("Current date:    {0}", DateTime.Now.ToString("HH:mm:ss"));
            
            Console.WriteLine(currentDateMessage);
        }
    }
}
