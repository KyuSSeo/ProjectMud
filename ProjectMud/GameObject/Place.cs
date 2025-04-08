using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud.GameObject
{
    public class Place : GameObj
    {
        private string scene;
        public Place(string scene, char symbol, Vectors pos)
            : base(ConsoleColor.Green, symbol, pos, false)
        {   
            this.scene = scene;
        }
        public override void Interact(Player player)
        {
            Game.SceneChange(scene);
        }

    }
}
