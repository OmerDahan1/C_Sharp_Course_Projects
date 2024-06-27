using System.Windows.Forms;

namespace Ex05
{
    public class SubmitButton : Button
    {
        public SubmitButton(int i_Top, int i_Left, int i_Width, int i_Height)
        {
            initializeSubmitButton(i_Top, i_Left, i_Width, i_Height);
        }

        private void initializeSubmitButton(int i_Top, int i_Left, int i_Width, int i_Height)
        {
            Top = i_Top + (i_Width / 2) - (i_Height / 2);
            Left = i_Left;
            Width = i_Width;
            Height = i_Height;
            Text = "-->>";
            Enabled = false;
        }
    }
}