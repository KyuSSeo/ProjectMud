using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//  TODO : 플레이어 거래기능


namespace ProjectMud
{
    public class Player
    {   //  플레이어 스텟
        private int curHp;
        private int maxHp;
        private int atk;
        private int def;

        //  인벤토리를 가짐
        private Inventory inventory;
        //  게임메뉴를 가짐
        private GameMenu gameMenu;

        //  맵에서의 위치정보를 가짐 
        public Vectors pos;
        public bool[,] map;
        public GameMenu GameMenu { get{ return gameMenu; } }
        public Inventory Inventory { get { return inventory; } }

        public int CurHp { get { return curHp; } }
        public int MaxHp { get { return maxHp; } }
        public int Atk { get { return atk; } }
        public int Def { get { return def; } }


        //  델리게이트
        public Action OnDied;
        public Action PcInteract;


        public Player()
        {
            //  인벤토리, 메뉴 기능과의 상호작용을 위한 소유
            inventory = new Inventory();
            gameMenu = new GameMenu();
            this.maxHp = 100;
            this.curHp = maxHp;
            this.atk = 5;
            this.def = 3;
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
            curHp -= (quantity - def/2);
            if (0 > curHp)
            {
                OnDied();
            }
        }

        public void StateMaxHpCh(int quantity)
        {
            maxHp += quantity;
        }
        public void StateDefCh(int quantity)
        {
            def += quantity;
        }

        public void StateAtkCh(int quantity)
        {
            atk += quantity;
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
