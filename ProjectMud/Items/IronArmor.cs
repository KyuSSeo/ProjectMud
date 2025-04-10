using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.GameObject;

namespace ProjectMud.Items
{
    public class IronArmor : EquipAble
    {
        public IronArmor(Vectors pos)
            : base(pos)
        {
            name = "철갑옷";
        }
        
        public override void EquipItem(Player player)
        {
            player.StateMaxHpCh(100);
            
        }

        public override void UnEquipItem(Player player)
        {
            player.StateMaxHpCh(100);
        }
    }
}
