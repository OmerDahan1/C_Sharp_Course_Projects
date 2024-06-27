namespace Ex04.Menus.Interfaces
{
    public class MenuAction : MenuItem, IMenuAction
    {
        private IMenuAction m_MenuActionInterface;

        public MenuAction(string i_Title, MenuItem i_ParentMenuItem) : base(i_Title, i_ParentMenuItem)
        {
        }

        public IMenuAction MenuActionInterface
        {
            get
            {
                return this.m_MenuActionInterface;
            }
            set
            {
                this.m_MenuActionInterface = value;
            }
        }

        public void PreformAction()
        {
            this.m_MenuActionInterface.PreformAction();
        }
    }
}
