using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_J
{
    internal class PlayerCastle
    {
        private PictureBox hitBox;
        private ProgressBar hpBar;
        private Form parrentForm;
        private int maxHp;
        private int currentHp;
        private int attackValue=20;
        
        public int AttackValue
        {
            get { return attackValue; }
        }

        public PictureBox HitBox { get { return hitBox; } }
        //private CastleState currentState;

        public PlayerCastle(Form form, int maxHp)
        {
            this.maxHp = maxHp;
            currentHp = maxHp;

            parrentForm = form;
            hitBox = new PictureBox();
            hitBox.SizeMode = PictureBoxSizeMode.AutoSize;
            hitBox.Image = Properties.Resources.castle_tier1;
            hitBox.BackColor = Color.Transparent;
            hitBox.Left = 869;
            hitBox.Top = 211;
            hpBar = new ProgressBar();
            hpBar.Maximum = maxHp;
            hpBar.Value = maxHp;


            hpBar.Left = hitBox.Left;
            hpBar.Top = hitBox.Top;

            parrentForm.Controls.Add(hpBar);
            parrentForm.Controls.Add(hitBox);
        }

        public void changeHp(int dmg)
        {
            currentHp -= dmg; 
            hpBar.Value = currentHp;
        }

        public int[] location()
        {
            int[] cords = {hitBox.Left,hitBox.Top};
            return cords;
        }
    }
}
