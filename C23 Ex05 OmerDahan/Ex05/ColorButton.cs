using Ex05;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class ColorButton : Button
    {
        private bool m_IsPicked;
        private bool m_IsSolution;
        private readonly List<Color> r_ColorsList;

        public ColorButton(int i_Top, int i_Left, int i_Width, int i_Height, bool i_IsSolution)
        {
            this.r_ColorsList = initializeColorsList();
            this.initializeColorButton(i_Top, i_Left, i_Width, i_Height, i_IsSolution);
        }

        public Action ColorPicked 
        { 
            get; 
            set; 
        }

        public bool IsPicked
        {
            get 
            { 
                return this.m_IsPicked; 
            }
        }

        private void initializeColorButton(int i_Top, int i_Left, int i_Width, int i_Height, bool i_IsSolution)
        {
            base.Top = i_Top;
            base.Left = i_Left;
            base.Width = i_Width;
            base.Height = i_Height;
            this.m_IsSolution = i_IsSolution;
            this.m_IsPicked = false;
            base.Enabled = false;
            base.Click += OnClick;
        }

        private List<Color> initializeColorsList()
        {
            List<Color> colors = new List<Color>
            {
                Color.Purple,
                Color.Red,
                Color.LawnGreen,
                Color.LightSkyBlue,
                Color.Blue,
                Color.Yellow,
                Color.Brown,
                Color.White
            };

            return colors;
        }

        protected virtual void OnClick(object sender, EventArgs e)
        {
            if (!this.m_IsSolution)
            {
                ColorPickForm colorPick = new ColorPickForm(this.r_ColorsList, base.Width, base.Height);
                if (colorPick.ShowDialog() == DialogResult.OK)
                {
                    this.m_IsPicked = true;
                    base.BackColor = colorPick.SelectedColor;
                    ColorPicked?.Invoke();
                }
            }
        }
    }
}
