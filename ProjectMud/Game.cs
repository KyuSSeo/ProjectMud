﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.Scenes;

namespace ProjectMud
{
    //  아이템의 속성
    public enum ItemType
    { Equip, ConsumAble, UnConsumAble }
    
    public static class Game
    {   //  장면 관리
        private static Dictionary<string, Scene> sceneDic;
        private static Scene curScene;
        
        //  게임 끝 관리
        private static bool gameEnd;
        
        //  플래이어 쓸래요
        private static Player player;
        public static Player Player { get { return player; } }
        
        //  이전 장면의 대한 정보를 저장할래요
        public static string prevSceneName;

        //  시작기능
        public static void Start()
        {
            //  커서 가릴래용
            Console.CursorVisible = false;
            //  게임 실행 할거에용
            gameEnd = false;
            //  플레이어 추가할래용
            player = new Player();
            //  PC데미지도 델리게이트로 관리해야 할까?
            //  델리게이트로 게임오버 관리할레요
            player.OnDied += Game.EndTriger;

            //  장면들을 추가
            sceneDic = new Dictionary<string, Scene>();
            sceneDic.Add("Title", new Title());
            sceneDic.Add("Field01", new Field01());
            sceneDic.Add("Town01", new Town01());
            sceneDic.Add("Normal01", new Normal01());
            sceneDic.Add("TestField01", new TestField01());
            sceneDic.Add("Trader01", new Trader01());
            sceneDic.Add("EndScene", new EndScene());
            
            //  첫 장면 설정 
            curScene = sceneDic["Title"];

        }

        //  동작기능
        public static void Run()
        {   //  시작
            Game.Start();
            //  종료까지 반복
            while (gameEnd == false)
            {
                Console.Clear();
                curScene.Render();
                Console.WriteLine();
                curScene.Input();
                Console.WriteLine();
                curScene.Update();
                Console.WriteLine();
                curScene.Result();
            }
            //  종료
            Game.End();
        }
        //  종료기능 
        public static void End()
        {
            gameEnd = true;
        }
        //  장면 전환기능
        public static void SceneChange(string sceneName)
        {
            //  이동 전에 맵 이름을 저장할래용
            prevSceneName = curScene.name;
            curScene.Exit();
            //  이동할게요
            curScene = sceneDic[sceneName];
            curScene.Enter();
        }

        //  장면을 끝난 화면으로 변경할래요
        public static void EndTriger()
        {
            SceneChange("EndScene");
        }

        //  UI출력할래요.
        public static void TextLine()
        {
            //아래쪽에다가 출력할래요
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(15, i);
                Console.WriteLine("*");
            }
            AddInfo();
        }

        public static void AddInfo()
        {
            Console.SetCursorPosition(17,0);
            Console.Write("- 맵 -");
            Console.SetCursorPosition(17, 1);
            Console.Write("{0}" , curScene.name);
            Console.SetCursorPosition(17, 3);
            Console.Write("Hp  / hp");
            Console.SetCursorPosition(17, 4);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("{0}", player.MaxHp);
            Console.ResetColor();
            Console.Write(" / ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", player.CurHp);
            Console.ResetColor();
            Console.SetCursorPosition(17, 6);
            Console.Write("M : 메뉴 열기");
            Console.SetCursorPosition(17, 7);
        }

    }
}
