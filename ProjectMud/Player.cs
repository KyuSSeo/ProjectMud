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
        public Inventory Inventory { get { return inventory; } }


        private GameMenu gameMenu;

        public Vectors pos;
        public bool[,] map;
        public GameMenu GameMenu { get{ return gameMenu; } }
        public int CurHp { get { return curHp; } }
        public int MaxHp { get { return maxHp; } }

        public Action OnDied;
        public Action PcInteract;
        public Player()
        {
            //  플레이어가 인벤토리를 가지지 않으면 상호작용이 불가능했음
            inventory = new Inventory();
            gameMenu = new GameMenu();
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
                OnDied();
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
                case ConsoleKey.M:
                    GameMenu.MenuOpen();
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
