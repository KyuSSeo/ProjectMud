﻿using ProjectMud.GameObject;
using ProjectMud.Items;

namespace ProjectMud.Scenes
{
    public class Field01 : FieldBase
    {
        public Field01()
        {
            name = "Field01";
            //  맵 정보 만들기
            mapData = new string[]
            {  //123456789
                "#########",//1
                "        #",//2
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
            gameObjs.Add(new Place("Town01", 'W', new Vectors(0, 1)));
            gameObjs.Add(new Potion(new Vectors(1, 6)));
            
        }
        public override void Enter()
        {
            // 플레이어 진입 장면에 따른 위치 설정
            if (Game.prevSceneName == "Town01")
            {
                Game.Player.pos = new Vectors(1, 1);
            }
            Game.Player.map = map;

        }
    }
}
