using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.GameObject
{
    public class HealingPool : GameObj
    {
        public HealingPool(Vectors pos)
            : base(ConsoleColor.Cyan, 'H', pos, false)
        {  }
        public override void Interact(Player player)
        {
            player.Heal(player.MaxHp);
            Util.InteractText("체력이 회복되었다!");
        }
    }
}
