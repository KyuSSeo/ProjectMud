using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.Scenes
{
    public class Trader01 : Scene
    {
        private ConsoleKey input;
        public Trader01()
        {
            name = "Trader01";
        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Render()
        {
            Console.WriteLine("상인01");
            Console.WriteLine("상인이다..");
            Console.WriteLine("01 - 거래한다.");
            Console.WriteLine("02 - 대화한다.");
            Console.WriteLine("03 - 마을로 돌아간다.");
        }

        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    //  TODO : 거래 기능 구현
                    break;
                case ConsoleKey.D2:
                    //  TODO : 간단한 대화기능 구현
                    break;
                case ConsoleKey.D3:
                    Util.PressKey("상인은 인사를 잔뜩 쓰고서 외쳤다. 안 살거면 나가.");
                    Game.SceneChange("Town01");
                    break;
                default:
                    break;
            }
        }

        public override void Update()
        {
         
        }
    }
}
