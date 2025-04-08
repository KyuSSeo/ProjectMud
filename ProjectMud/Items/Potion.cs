using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.GameObject;

namespace ProjectMud.Items
{
    public class Potion : Item
    {
        public Potion(Vectors pos)
        : base('I',pos)
        {
            name = "포션";
            description = "마시면 체력을 회복한다. 딸기맛이다.";
        }
        public override void Use()
        {
            Game.Player.Heal(30);
        }
    }
}
