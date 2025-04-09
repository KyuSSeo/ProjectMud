using ProjectMud.GameObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud
{
    public class GameMenu
    {
        private List<string> options;
        private Stack<string> stack;
        private int selectIndex;
        private ConsoleKey input;
        private Inventory inventory;
        public Inventory Inventory { get { return inventory; } }

        public GameMenu()
        {
            inventory = new Inventory();
            options = new List<string>();
            stack = new Stack<string>();
        }


        public void MenuOpen() 
        {
            stack.Push("MenuMain");
            while (stack.Count>0)
            {
                Console.Clear();
                switch (stack.Peek())
                {
                    case "MenuMain":
                        MenuMain(); break;
                    case "OpenItem":
                        OpenItem(); break;
                    case "PlayerInfo":
                        break;
                    case "SaveEnd":
                        break;
                    case "GameEnd":
                        break;
                }
            }
            
        }

        private void OpenItem()
        {
            inventory.ItemOpen();
        }
        private void MenuMain()
        {
            PrintMenu();
            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    stack.Push("OpenItem");
                    break;
                case ConsoleKey.D2:
                    stack.Push("PlayerInfo");
                    break;
                case ConsoleKey.D3:
                    stack.Push("SaveEnd");
                    break;
                case ConsoleKey.D4:
                    stack.Push("GameEnd");
                    break;
                case ConsoleKey.D0:
                    stack.Pop();
                    break;
            }
        }

        public void PrintMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("=========================");
            Console.WriteLine("1. 가방을 열기");
            Console.WriteLine("2. 캐릭터의 정보를 확인하기(미구현)");
            //  TODO : 정보확인 구현 
            Console.WriteLine("3. 저장 / 불러오기 (미구현)");
            // TODO : 세이브 구현
            Console.WriteLine("4. 게임을 종료하기");
            Console.WriteLine("0. 메뉴를 닫기");
            Console.WriteLine("=========================");


        }
    }
}
