using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.GameObject
{
    public class PoisonPool : GameObj
    {
        public PoisonPool(Vectors pos)
            : base(ConsoleColor.Magenta, 'D', pos, false)
        { }
        public override void Interact(Player player)
        {
            player.Damaged(40);
        }
    }
}
