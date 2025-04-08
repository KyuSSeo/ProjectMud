using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.GameObject;

namespace ProjectMud.Scenes
{
    public class Field01 : Scene
    {
        //  맵 구현을 위한 bool 배열 선언
        private bool[,] map;
        private string[] mapData;
        private List<GameObj> gameObjs;

        private ConsoleKey input;
        public Field01()
        {
            //  맵 정보 만들기
            mapData = new string[]
            {  //123456789
                "#########",//1
                "#       #",//2
                "#       #",//3
                "#       #",//4
                "#       #",//5
                "#       #",//6
                "#       #",//7
                "#       #",//8
                "#########" //9
            };

            //  반복문으로 맵 설정
            map = new bool[9, 9];

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    map[y, x] = mapData[y][x] == '#' ? false : true;
                }
            }

            //  오브젝트 설정
            gameObjs = new List<GameObj>();
            gameObjs.Add(new Place("Town01", 'T', new Vectors(1, 1)));
            
            // 플레이어 위치 설정
            Game.Player.pos = new Vectors(1,2);
            Game.Player.map = map;

            }
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
