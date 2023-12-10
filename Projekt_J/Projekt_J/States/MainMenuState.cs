using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Projekt_J.States
{
    internal class MainMenuState : GameState
    {
        private PictureBox newGameButton, exitGameButton, optionButton;
        private GameState newState;
        
        public MainMenuState(Form parrentform) : base(parrentform)
        {
            newState = this;

            parrentForm.BackgroundImage = Properties.Resources.Menu;

            newGameButton = new PictureBox();
            newGameButton.SizeMode = PictureBoxSizeMode.AutoSize;
            newGameButton.BackColor = Color.Transparent;
            newGameButton.Image = Properties.Resources.NewGame_removebg_preview;
            newGameButton.Left = 52;
            newGameButton.Top = 122;
            newGameButton.MouseClick += new MouseEventHandler(NewGameButton_Click);

            optionButton = new PictureBox();
            optionButton.SizeMode = PictureBoxSizeMode.AutoSize;
            optionButton.BackColor = Color.Transparent;
            optionButton.Image = Properties.Resources.opt_removebg_preview;
            optionButton.Left = 52;
            optionButton.Top = 282;
            optionButton.MouseClick += new MouseEventHandler(ExitGameButton_Click);

            exitGameButton = new PictureBox();
            exitGameButton.SizeMode = PictureBoxSizeMode.AutoSize;
            exitGameButton.BackColor = Color.Transparent;
            exitGameButton.Image = Properties.Resources.exit_removebg_preview;
            exitGameButton.Left = 52;
            exitGameButton.Top = 442;
            exitGameButton.MouseClick += new MouseEventHandler(OptionButton_Click);

            parrentForm.Controls.Add(newGameButton);
            parrentForm.Controls.Add(exitGameButton);
            parrentForm.Controls.Add(optionButton);

            newGameButton.BringToFront();
            exitGameButton.BringToFront();
            optionButton.BringToFront();

        }

        public override GameState Run()
        {
            return newState;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            parrentForm.Controls.Remove(newGameButton);
            parrentForm.Controls.Remove(exitGameButton);
            parrentForm.Controls.Remove(optionButton);
            newGameButton.Dispose();
            optionButton.Dispose();
            exitGameButton.Dispose();
            exitGameButton = null;
            newGameButton = null;
            optionButton = null;

            newState = new InGameState(parrentForm);
        } 

        private void ExitGameButton_Click(object sender, EventArgs e)
        {
            parrentForm.Close();

        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            parrentForm.Close();
        }


        
    }
}
