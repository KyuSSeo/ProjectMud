using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.Scenes
{
    public class Title : Scene
    {
        public Title()
        {
            name = "Title";
        }
        public override void Input()
        {
            Util.PressKey("");
        }

        public override void Render()
        {


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("         The Title");
            Console.WriteLine(); 
            Console.WriteLine();

        }

        public override void Result()
        {
            Game.SceneChange("Town01");
        }

        public override void Update()
        {
        }
    }
}
