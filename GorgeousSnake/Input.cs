using System.Collections;
using System.Windows.Forms;

namespace GorgeousSnake
{
    internal class Input
    {
        //TODO: Don't use comments - use self-descriptive names instead
        private static Hashtable KeyTable = new Hashtable();

        public static bool IsKeyPressed(Keys key)
        {
            if (KeyTable[key] == null)
            {
                return false;
            }

            return (bool)KeyTable[key];
        }

        public static void ChangeState(Keys key, bool state)
        {
            KeyTable[key] = state;
        }
    }
}
