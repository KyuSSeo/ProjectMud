using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.GameObject
{
    public abstract class EquipAble : Item
    {
        public ItemType ItemType;
        public EquipAble(Vectors pos)
            : base('I', pos)    
        {   }
        public override void Use()
        {
            if (isEquip == false)
            {
                isEquip = true;
                EquipItem(Game.Player);
            }
            else
            {
                isEquip = false;
                UnEquipItem(Game.Player);
            }
        }

        public abstract void EquipItem(Player player);
        public abstract void UnEquipItem(Player player);
    }
}
