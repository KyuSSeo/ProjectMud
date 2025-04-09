using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.Scenes
{
    public class EndScene : Scene
    {

        private ConsoleKey input;

        public EndScene()
        {
            name = "EndScene";
        }
        public override void Input()
        {
            Util.PressKey("");
        }

        public override void Render()
        {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("       당신의 눈앞이 깜깜해졌다.");
            Console.WriteLine();
            Console.WriteLine();

        }

        public override void Result()
        {
            Game.End();
        }

        public override void Update()
        {
        }
    }
}
