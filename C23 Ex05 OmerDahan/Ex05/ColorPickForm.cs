using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class ColorPickForm : Form
    {
        private readonly int r_CellMargin;
        private readonly int r_WindowPadding;
        private Color m_SelectedColor;

        public ColorPickForm(List<Color> i_ColorsList, int i_ButtonWidth, int i_ButtonHeight)
        {
            this.r_CellMargin = 8;
            this.r_WindowPadding = 12;
            initializeColorPickForm(i_ColorsList, i_ButtonWidth, i_ButtonHeight);
        }

        public Color SelectedColor
        {
            get
            {
                return m_SelectedColor;
            }
        }

        private void initializeColorPickForm(List<Color> i_ColorsList, int i_ButtonWidth, int i_ButtonHeight)
        {
            int numberOfColorsInRow = i_ColorsList.Count / 2;
            int windowWidth = (i_ButtonWidth * numberOfColorsInRow) + (this.r_CellMargin * (numberOfColorsInRow - 1)) + (2 * this.r_WindowPadding);
            int windowHeight = (2 * (i_ButtonHeight + this.r_CellMargin)) + (2 * this.r_WindowPadding);

            base.Text = "Pick A Color:";
            base.ClientSize = new Size(windowWidth, windowHeight);
            foreach (Color colorToAdd in i_ColorsList)
            {
                Button buttonColor = new Button()
                {
                    BackColor = colorToAdd,
                    Width = i_ButtonWidth,
                    Height = i_ButtonHeight
                };

                int i = i_ColorsList.IndexOf(colorToAdd);
                int numberOfRow = i < numberOfColorsInRow ? 0 : 1;
                int numberOfCol = i % numberOfColorsInRow;
                buttonColor.Left = numberOfCol * (buttonColor.Width + this.r_CellMargin) + this.r_WindowPadding;
                buttonColor.Top = numberOfRow * (buttonColor.Height + this.r_CellMargin) + this.r_WindowPadding;
                buttonColor.Click += ColorButtonHandle_Click;
                base.Controls.Add(buttonColor);
            }
        }

        private void ColorButtonHandle_Click(object sender, EventArgs e)
        {
            this.m_SelectedColor = (sender as Button).BackColor;
            base.DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ColorPickForm
            // 
            this.ClientSize = new Size(284, 261);
            this.Name = "ColorPickForm";
            this.Load += this.ColorPickForm_Load;
            this.ResumeLayout(false);

        }

        private void ColorPickForm_Load(object sender, EventArgs e)
        {

        }
    }
}
