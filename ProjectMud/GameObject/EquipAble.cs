using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.GameObject
{
    public abstract class EquipAble : Item
    {
        //  장비 여부를 아이템이 관리하게 만들기
        //  TODO : 장비 만들어서 테스트 해보기
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
