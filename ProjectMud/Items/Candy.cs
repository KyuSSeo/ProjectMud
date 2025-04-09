using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.GameObject;

namespace ProjectMud.Items
{
    public class Candy : Item
    {
        public Candy(Vectors pos)
        : base('I',pos)
        {
            name = "수상한 사탕";
            description = "포도맛이다. 먹으면 배가 아프다.";
            itemType = ItemType.ConsumAble;
        }
        public override void Use()
        {
            Game.Player.Damaged(5);
        }
    }
}
