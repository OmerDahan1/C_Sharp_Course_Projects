using System;

namespace Ex04.Menus.Delegates
{
    public class MenuAction : MenuItem
    {
        public event Action PreformAction;

        public MenuAction(string i_Title, MenuItem i_ParentMenuItem) : base(i_Title, i_ParentMenuItem)
        {
        }

        internal virtual void OnPreformAction()
        {
            PreformAction?.Invoke();
        }
    }
}