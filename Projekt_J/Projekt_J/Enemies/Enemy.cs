using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using Projekt_J.Properties;
using Projekt_J.Enemies;

namespace Projekt_J
{
    internal abstract class Enemy
    {
        protected PictureBox hitBox;
        private ProgressBar hpBar;
        private Form parrentForm;
        private Timer enemyTimer;


        private int maxHp;
        private int attackValue;
        private int currentHP;
        
        private Random rnd=new Random();
        private int speed=10;
        private PlayerCastle target;



        public PictureBox HitBox
        { get { return hitBox; } }
        public ProgressBar HPBar
        { get { return hpBar; } }


        public Enemy(Form parrentForm,PlayerCastle target,int maxHp, int attackValue, int[] cords)
        {
            //setting values
            this.parrentForm = parrentForm;
            this.target = target;
            this.maxHp = maxHp;
            currentHP = maxHp;
            this.attackValue = attackValue;

            //setting position
            enemyTimer = new Timer();
            enemyTimer.Interval = speed;
            enemyTimer.Tick += new EventHandler(Move);
            hitBox = new PictureBox();
            hitBox.SizeMode = PictureBoxSizeMode.AutoSize;
            hitBox.BackColor = Color.Transparent;
            hitBox.Left = cords[0];
            hitBox.Top = cords[1];
            hpBar = new ProgressBar();
            hpBar.Maximum = maxHp;
            hpBar.Value = maxHp;
            hpBar.Minimum = 0;
            hpBar.Height = 10;
            hpBar.Left = hitBox.Left-20;
            hpBar.Top = hitBox.Top-hpBar.Height-5;      
            
            //adding zombies to game
            parrentForm.Controls.Add(hpBar);
            parrentForm.Controls.Add(hitBox);
            enemyTimer.Start();
        }


        public bool takeDMG(int dmg)
        {
            currentHP -= dmg;
            if(currentHP <= 0)
            {
                hpBar.Value = 0;
                parrentForm.Controls.Remove(hpBar);
                parrentForm.Controls.Remove(HitBox);            
                hpBar.Dispose();
                hitBox.Dispose();
                hitBox = null;
                hpBar = null;
                return true;
            }
            else
            {
                hpBar.Value = currentHP;
            }
            return false;
        }
        protected virtual void Move(object sender, EventArgs e)
        {
            if (hitBox != null)
            {
                if (hitBox.Left + HitBox.Width >= target.HitBox.Left)
                {
                    Attack();
                }
                else
                {
                    hitBox.Left += speed / 5;
                    hpBar.Left += speed / 5;
                }
            }
        }

        protected abstract int Attack();



    }
}
