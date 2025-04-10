using System.Runtime.Serialization.Formatters;

namespace ProjectMud
{
    public class GameMenu
    {
        private List<string> options;
        private Stack<string> stack;
        private int selectIndex;
        private ConsoleKey input;
        public GameMenu()
        {
            options = new List<string>();
            stack = new Stack<string>();
        }


        public void MenuOpen()
        {
            stack.Push("MenuMain");
            while (stack.Count > 0)
            {
                Console.Clear();
                switch (stack.Peek())
                {
                    case "MenuMain":
                        MenuMain(); break;
                    case "OpenItem":
                        OpenItem(); break;
                    case "PlayerInfo":
                        PlayerInfo(); break;
                    case "SaveLoad":
                        SaveLoad(); break;
                    case "TitleOrEnd":
                        TitleOrEnd(); break;
                }
            }

        }
        private void isExist()
        {
            int num = Game.Player.Inventory.equips.Count;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("착용하고 있는 장비 {0} : {1}", i + 1, Game.Player.Inventory.equips[i].name);
            }
        }
        private void PlayerInfo()
        {
            Console.WriteLine("**************************");
            Console.WriteLine($"플래이어의 Hp / hp  : {Game.Player.MaxHp} / {Game.Player.CurHp}");
            Console.WriteLine("플레이어의 공격력 : {0}", Game.Player.Atk);
            Console.WriteLine("플레이어의 방어력 : {0}", Game.Player.Def);
            isExist();
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
