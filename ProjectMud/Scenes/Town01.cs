using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.Scenes
{
    public class Town01 : Scene
    {
        private ConsoleKey input;
        public Town01()
        {
            name = "Town01";
        }
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Render()
        {
            Console.WriteLine("마을01");
            Console.WriteLine("마을이다.");
            Console.WriteLine("01 - 필드로");
        }

        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    Util.PressKey("마을 밖으로");
                    Game.SceneChange("Field01");
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
