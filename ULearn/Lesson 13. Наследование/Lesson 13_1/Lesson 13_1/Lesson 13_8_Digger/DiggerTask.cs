using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand()
            {
                DeltaX = 0,
                DeltaY = 0,
                TransformTo = null
            };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
            //throw new NotImplementedException();
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    public class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            if (Game.KeyPressed == System.Windows.Forms.Keys.Up)
                return new CreatureCommand() { DeltaX = 0, DeltaY = -1, TransformTo = null };
            else if (Game.KeyPressed == System.Windows.Forms.Keys.Left)
                return new CreatureCommand() { DeltaX = -1, DeltaY = 0, TransformTo = null };
            else if (Game.KeyPressed == System.Windows.Forms.Keys.Down)
                return new CreatureCommand() { DeltaX = 0, DeltaY = 1, TransformTo = null };
            else if (Game.KeyPressed == System.Windows.Forms.Keys.Right)
                return new CreatureCommand() { DeltaX = 1, DeltaY = 0, TransformTo = null };
            else
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            //CreatureCommand a = conflictedObject.Act(0, 0);
            return true;
            //throw new Exception($"The object {this} falls out of the game field");
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }

}
