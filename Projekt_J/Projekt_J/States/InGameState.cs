using Projekt_J.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_J.States
{
    internal class InGameState : GameState
    {

        private EnemyFabric monsterINC;
        private PlayerCastle playerCastle;
        private List<Enemy> enemies;
        public InGameState(Form parrentform) : base(parrentform)
        {
            parrentForm.BackgroundImage = Properties.Resources.Background1;

            playerCastle = new PlayerCastle(parrentForm, 100);
            monsterINC = new EnemyFabric(parrentForm, playerCastle);
            enemies = monsterINC.CreateEnemy();

        }

        public override GameState Run()
        {
            return this;
        }
    }
}
