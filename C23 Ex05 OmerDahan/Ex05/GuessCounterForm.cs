using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class GuessCounterForm : Form
    {
        private Button m_ButtonStart;
        private Button m_ButtonNumberOfGuesses;
        private readonly int r_ButtonStartTop = 75;
        private readonly int r_ButtonStartWidth = 100;
        private readonly int r_ButtonNumberOfGuessesTop = 15;
        private readonly int r_ButtonNumberOfGuessesLeft = 20;
        private readonly int r_ButtonNumberOfGuessesWidth = 220;
        private readonly int r_ButtonNumberOfGuessesHeight = 25;
        private int m_CurrentNumberOfGuesses;
        private int m_MinimalNumberOfGuesses;
        private int m_MaximalNumberOfGuesses;

        public GuessCounterForm(int i_MinimalNumberOfGuesses, int i_MaximalNumberOfGuesses)
        {
            this.m_MinimalNumberOfGuesses = i_MinimalNumberOfGuesses;
            this.m_MaximalNumberOfGuesses = i_MaximalNumberOfGuesses;
            this.m_CurrentNumberOfGuesses = this.m_MinimalNumberOfGuesses;
            this.initializeGuessCounterForm();
        }

        public int CurrentNumberOfGuesses
        {
            get
            {
                return this.m_CurrentNumberOfGuesses;
            }
        }

        private void initializeGuessCounterForm()
        {
            this.createNumberOfGuessesButton();
            this.createStartButton();
            this.setFormProperties();
        }

        private void createNumberOfGuessesButton()
        {
            this.m_ButtonNumberOfGuesses = new Button()
            {
                Text = string.Format("Number of Chances: {0}", this.m_CurrentNumberOfGuesses),
                Location = new Point(this.r_ButtonNumberOfGuessesLeft, this.r_ButtonNumberOfGuessesTop),
                Size = new Size(this.r_ButtonNumberOfGuessesWidth, this.r_ButtonNumberOfGuessesHeight)
            };

            this.m_ButtonNumberOfGuesses.Click += m_ButtonNumberOfGuesses_Click;
            base.Controls.Add(this.m_ButtonNumberOfGuesses);
        }

        private void createStartButton()
        {
            this.m_ButtonStart = new Button()
            {
                Text = "Start",
                Location = new Point(this.m_ButtonNumberOfGuesses.Right - this.r_ButtonStartWidth, this.r_ButtonStartTop),
                Size = new Size(this.r_ButtonStartWidth, this.r_ButtonNumberOfGuessesHeight)
            };

            this.m_ButtonStart.Click += m_ButtonStart_Click;
            base.Controls.Add(this.m_ButtonStart);
        }

        private void setFormProperties()
        {
            base.Text = "Bool Pgia";
            base.ClientSize = new Size((int)(this.r_ButtonNumberOfGuessesWidth * 1.18), (int)(this.r_ButtonNumberOfGuessesHeight * 4.5));
            base.StartPosition = FormStartPosition.CenterScreen;
        }


        private void m_ButtonNumberOfGuesses_Click(object sender, EventArgs e)
        {
            if (this.m_CurrentNumberOfGuesses < this.m_MaximalNumberOfGuesses)
            {
                this.m_CurrentNumberOfGuesses++;
            }
            else
            {
                this.m_CurrentNumberOfGuesses = this.m_MinimalNumberOfGuesses;
            }

            this.m_ButtonNumberOfGuesses.Text = string.Format("Number of Chances: {0}", this.m_CurrentNumberOfGuesses);
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GuessCounterForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "GuessCounterForm";
            this.Load += new System.EventHandler(this.GuessCounterForm_Load);
            this.ResumeLayout(false);

        }

        private void GuessCounterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
