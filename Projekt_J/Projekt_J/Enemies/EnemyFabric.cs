using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using Projekt_J.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace Projekt_J.Enemies
{
    internal class EnemyFabric
    {
        private int lvl;
        private Form parrentForm;
        private PlayerCastle playerCastle;
        private Random rnd=new Random();


        public EnemyFabric(Form parrentForm,PlayerCastle playerCastle)
        {
            lvl = 1;
            this.parrentForm = parrentForm;
            this.playerCastle = playerCastle;
        }

        public void ChangeMonsteLvL(int newLvL)
        {
            lvl = newLvL; 
        }

        public List<Enemy> CreateEnemy()
        {
            List<Enemy> list = new List<Enemy>();
            for (int i = 0; i < 10 * lvl; i++)
            {
                int[] cords = {rnd.Next(-i*100-200,-i*100),rnd.Next(334,639) };
                Enemy enemy= new WarriorEnemy(parrentForm, playerCastle, lvl * 50, 10, cords);
                enemy.HitBox.MouseClick += new MouseEventHandler((s, e1) => enemy.takeDMG(playerCastle.AttackValue));
                list.Add(enemy);
            }

            return list;
        }

    }
}
