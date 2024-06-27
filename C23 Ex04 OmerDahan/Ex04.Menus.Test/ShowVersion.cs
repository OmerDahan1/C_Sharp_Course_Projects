using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    internal class ShowVersion : IMenuAction
    {
        public void PreformAction()
        {
            Console.WriteLine("Version: 23.3.4.9835");
        }
    }
}
