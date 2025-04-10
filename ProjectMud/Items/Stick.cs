using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.GameObject;

namespace ProjectMud.Items
{
    public class Stick : EquipAble
    {
        public Stick(Vectors pos) 
            : base(pos)
        {
            name = "막대기";
        }
        public override void EquipItem(Player player)
        {
            player.StateAtkCh(1);
        }

        public override void UnEquipItem(Player player)
        {
            player.StateAtkCh(-1);
        }
    }
}
