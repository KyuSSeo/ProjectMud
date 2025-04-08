using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.GameObject;

namespace ProjectMud.Scenes
{
    //  상속 클래스로 구현할래용
    public abstract class FieldBase : Scene
    {
        //  맵 정보와 오브젝트 정보를 상속받는 클래스가 가졌으면 해요.
        protected bool[,] map;
        protected string[] mapData;
        protected List<GameObj> gameObjs;

        private ConsoleKey input;
       
        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Render()
        {
            PrintMap();
            Util.TextLine();

            foreach (GameObj go in gameObjs)
            {
                go.PrintObj();
            }

            
            Game.Player.PlayerPrint();
        }

        public override void Result()
        {
            foreach (GameObj go in gameObjs)
            {
                if (Game.Player.pos == go.pos)
                {
                    go.Interact(Game.Player);
                }
            }
        }

        public override void Update()
        {
            Game.Player.Move(input);
        }
        //  맵 그리기
        private void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (map[y, x] == true)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write('#');
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
