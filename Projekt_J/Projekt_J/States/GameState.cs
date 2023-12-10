using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using Projekt_J.Properties;
using System.ComponentModel;

namespace Projekt_J.States
{
    internal abstract class GameState
    {
        protected Form parrentForm;

        public GameState(Form parrentform) 
        {
            this.parrentForm = parrentform;
        }

        public abstract GameState Run();
    }
}
