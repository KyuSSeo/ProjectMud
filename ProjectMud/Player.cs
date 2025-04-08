using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//  TODO : 플레이어 장비 착용
//  TODO : 플레이어 거래기능


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

            inventory = new Inventory();
            this.maxHp = 100;
            this.curHp = maxHp;
        }

        public void Heal(int quantity)
        {
            curHp += quantity;
            if (curHp > maxHp)
            {
                curHp = maxHp;
            }
        }
        public void Damaged(int quantity)
        {
            curHp -= quantity;
            if (0 > curHp)
            {
                Game.End();    
            }
        }
        public void PlayerPrint()
        {
            Console.SetCursorPosition(pos.x, pos.y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write('P');
            Console.ResetColor();
        }

        public void Action(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    Move(input);
                    break;
                case ConsoleKey.I:
                    inventory.Open();
                    break;
                default:
                    break;
            }

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
