using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class ResultButton : Button
    {
        public ResultButton(int i_Top, int i_Left, int i_Width, int i_Height)
        {
            this.initializeResultButton(i_Top, i_Left, i_Width, i_Height);
        }

        private void initializeResultButton(int i_Top, int i_Left, int i_Width, int i_Height)
        {
            base.Top = i_Top;
            base.Left = i_Left;
            base.Width = i_Width;
            base.Height = i_Height;
            base.Enabled = false;
        }
    }
}
