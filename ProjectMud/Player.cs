using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud
{
    public class Player
    {
        private int curHp;
        private int maxHp;
        private Inventory inventory;

        public Vectors pos;
        public bool[,] map;
        public Inventory Inventory { get { return inventory; } }
        public int CurHp { get { return curHp; } }
        public int MaxHp { get { return maxHp; } }


        public Player()
        {
            this.maxHp = 100;
            this.curHp = maxHp;
            this.inventory = inventory;
        }

        public void Heal(int quantity)
        {
            curHp += quantity;
            if (curHp > maxHp)
            {
                curHp = maxHp;
            }
        }

        public void PlayerPrint()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('P');
            Console.ResetColor();
        }
        public void Move(ConsoleKey input)
        {
            Vectors targetPos = pos;
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    targetPos.x--;
                    break;
                case ConsoleKey.UpArrow:
                    targetPos.y--;
                    break;
                case ConsoleKey.RightArrow:
                    targetPos.x++;
                    break;
                case ConsoleKey.DownArrow:
                    targetPos.y++;
                    break;
                default:
                    break;
            }
            if (map[targetPos.y, targetPos.x] == true)
            {
                pos = targetPos;
            }
        }
    }
}
