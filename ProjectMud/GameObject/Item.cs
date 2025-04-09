using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.GameObject
{
    public abstract class Item : GameObj
    {
        //  아이템에는 이름과 설명이 필요해요.
        public string name;
        public string description;

        public Item(char symbol, Vectors pos) 
            : base(ConsoleColor.Yellow, symbol, pos, true)
        {
        }
                 
                 
        //  플레이어 인벤토리로 쏘옥
        public override void Interact(Player player)
        {
            player.Inventory.Add(this);
            Util.InteractText("아이템을 주웠다!");
        }

        //  아이템 각각의 사용 기능을 넣기
        public abstract void Use();
    }
}
