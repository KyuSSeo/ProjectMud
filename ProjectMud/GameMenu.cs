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
        private string notthig = "없음";
        public GameMenu()
        {
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
                        MenuMain();     break;
                    case "OpenItem":
                        OpenItem();     break;
                    case "PlayerInfo":
                        PlayerInfo();   break;
                    case "SaveLoad":
                        SaveLoad();     break;
                    case "TitleOrEnd":
                        TitleOrEnd();   break;
                }
            }
            
        }
        private string isExist(int equipNum)
        {
            string result = "0";
            /*
             *  장비품 리스트의 장비한 번호를 보고
             *  장비한 번호에 있는 장비 이름을 반환하고 싶어
             *  
             *  그런데 만약 장비하고 있는 장비가 없다면
             *  "장비하지 않음" 을 반환하고 싶어
             */

            result = Game.Player.Inventory.equips[equipNum].name; 

            return result;
        }
        private void PlayerInfo()
        {   
            Console.WriteLine("**************************");
            Console.WriteLine($"플래이어의 Hp / hp  : {Game.Player.MaxHp} / {Game.Player.CurHp}");
            // TODO : 공격, 방어 구현
            //Console.WriteLine("플레이어의 공격력 : {0}");
            //Console.WriteLine("플레이어의 방어력 : {0}");
            Console.WriteLine("플레이어의 장비 1 : {0}", isExist(0));
            Console.WriteLine("플레이어의 장비 2 : {0}");
            Console.WriteLine("플레이어의 장비 3 : {0}");
            Console.WriteLine("플레이어의 장비 4 : {0}");
            Console.WriteLine("**************************");
            Util.PressKey("");
            stack.Pop();
        }
        private void SaveLoad()
        {
            //  TODO : 세이브 로드 기능 구현
            Util.PressKey("");
            stack.Pop();
        }
        private void TitleOrEnd()
        {
            Console.WriteLine("1. 타이틀로.");
            Console.WriteLine("2. 게임을 종료.");
            Console.WriteLine("0. 메뉴로 돌아간다..");

            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    stack.Clear();
                    Game.SceneChange("Title");
                    break;
                case ConsoleKey.D2:
                    stack.Clear();
                    Game.SceneChange("EndScene");
                    break;
                case ConsoleKey.D0:
                    stack.Pop();
                    break;
            }
        }

        private void OpenItem()
        {
            Game.Player.Inventory.ItemOpen();
            stack.Pop();
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
                    stack.Push("SaveLoad");
                    break;
                case ConsoleKey.D4:
                    stack.Push("TitleOrEnd");
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
            Console.WriteLine("2. 캐릭터의 정보를 확인하기");
            Console.WriteLine("3. 저장 / 불러오기 (미구현)");
            // TODO : 세이브 구현
            Console.WriteLine("4. 게임을 종료하기");
            Console.WriteLine("0. 메뉴를 닫기");
            Console.WriteLine("=========================");


        }
    }
}
