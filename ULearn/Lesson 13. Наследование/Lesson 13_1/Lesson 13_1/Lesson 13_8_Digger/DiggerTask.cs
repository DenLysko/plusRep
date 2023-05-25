using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digger;

namespace Digger
{
    public class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            if (Game.KeyPressed == System.Windows.Forms.Keys.Up && y > 0 &&
                Game.Map[x, y - 1]?.GetType() != typeof(Digger.Sack))
            {
                return new CreatureCommand() { DeltaX = 0, DeltaY = -1, TransformTo = null };
            }
            else if (Game.KeyPressed == System.Windows.Forms.Keys.Left && x > 0 &&
                Game.Map[x - 1, y]?.GetType() != typeof(Digger.Sack))
            {
                //if (Game.Map[x - 1, y - 1]?.GetType() == typeof(Digger.Sack))
                //{
                //    var creature = Game.Map[x - 1, y - 1];
                //    Animations.Add(
                //    new CreatureAnimation
                //    {
                //        Command = new CreatureCommand() { DeltaX = 0, DeltaY = 1, TransformTo = null },
                //        Creature = creature,
                //        Location = new System.Drawing.Point(x * GameState.ElementSize, y * GameState.ElementSize),
                //        TargetLogicalLocation = new System.Drawing.Point(x, y + 1)
                //    });
                //}
                return new CreatureCommand() { DeltaX = -1, DeltaY = 0, TransformTo = null };
            }
            else if (Game.KeyPressed == System.Windows.Forms.Keys.Down && Game.MapHeight - y > 1 &&
                Game.Map[x, y + 1]?.GetType() != typeof(Digger.Sack))
            {
                return new CreatureCommand() { DeltaX = 0, DeltaY = 1, TransformTo = null };
            }
            else if (Game.KeyPressed == System.Windows.Forms.Keys.Right && Game.MapWidth - x > 1 &&
                Game.Map[x + 1, y]?.GetType() != typeof(Digger.Sack))
            {
                return new CreatureCommand() { DeltaX = 1, DeltaY = 0, TransformTo = null };
            }
            else
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
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

    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand()
            {
                DeltaX = 0,
                DeltaY = 0,
                TransformTo = null,
            };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
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

    public class Sack : ICreature
    {
        public int dropLength = 0;
        public bool needToTransformToGold = false;
        public CreatureCommand Act(int x, int y)
        {
            if (x < Game.MapWidth && y < Game.MapHeight - 1)
            {
                if (Game.Map[x, y + 1]?.GetType() == null)
                {
                    dropLength++;
                    if (dropLength > 1)
                        needToTransformToGold = true;

                    return new CreatureCommand() { DeltaX = 0, DeltaY = 1, TransformTo = null };
                }
                else if (Game.Map[x, y + 1]?.GetType() == typeof(Digger.Player))
                {

                }
            }    
                if (Game.Map[x, y + 1]?.GetType() == null || Game.Map[x, y + 1]?.GetType() == typeof(Digger.Player))
            {
                dropLength++;
                if (dropLength > 1)
                    needToTransformToGold = true;
                
                return new CreatureCommand() { DeltaX = 0, DeltaY = 1, TransformTo = null };
            }
            if (needToTransformToGold)
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = null };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            //    try
            //    {
            //        var a = (Player)conflictedObject;
            //    }
            //    catch
            //    {
            //        return false;
            //    }
            Game.Scores += 10;
            return true;
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }
}
