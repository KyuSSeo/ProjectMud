using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.GameObject
{
    public abstract class EquipAble : Item
    {
        //  장비 여부를 아이템이 관리하게 만들기\
        public bool isEquip;

        public EquipAble(Vectors pos)
            : base('I', pos)    
        {
            isEquip = false;
        }

        public override void Use()
        {
            if (isEquip == false)
            {   //한줄로 표현하는 방식이 있던 것 같은데.
                isEquip = true;
                EquipItem();
            }
            else { 
                isEquip = false;
                UnEquipItem();
            }
        }
        public abstract void EquipItem();
        public abstract void UnEquipItem();
    }
}
