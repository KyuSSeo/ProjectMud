﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.Scenes
{
    public class Test03 : Scene
    {

        private ConsoleKey input;
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }


        public override void Render()
        {
            Console.WriteLine("장소 - 테스트03");
            Console.WriteLine();
            Console.WriteLine("1 - 테스트01");
            Console.WriteLine("2 - 테스트02");
            Console.WriteLine("3 - 필드 01");        }

        public override void Result()
        {
        }

        public override void Update()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    Util.PressKey("테스트 01로 이동");
                    Game.SceneChange("Test01");
                    break;
                case ConsoleKey.D2:

                    Util.PressKey("테스트 02로 이동");
                    Game.SceneChange("Test02");
                    break;
                case ConsoleKey.D3:

                    Util.PressKey("필드로");
                    Game.SceneChange("Field01");
                    break;
                default:
                    break;
            }
        }
    }
}
