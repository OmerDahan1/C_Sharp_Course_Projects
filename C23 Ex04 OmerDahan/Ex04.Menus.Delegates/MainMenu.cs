namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private MenuItem m_MenuItem;

        public MainMenu(MenuItem i_MenuItem)
        {
            this.m_MenuItem = i_MenuItem;
        }

        public void Show()
        {
            this.m_MenuItem.Show();
        }
    }
}