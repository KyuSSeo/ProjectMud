using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.Scenes;

namespace ProjectMud
{
    public static class Game
    {
        private static Dictionary<string, Scene> sceneDic;
        private static Scene curScene;
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

            sceneDic = new Dictionary<string, Scene>();
            sceneDic.Add("Title", new Title());
            sceneDic.Add("Field01", new Field01());
            sceneDic.Add("Town01", new Town01());
            sceneDic.Add("Normal01", new Normal01());

            curScene = sceneDic["Title"];

        }

        //  동작기능
        public static void Run()
        {
            Game.Start();
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
            Game.End();
        }
        //  종료기능 
        public static void End()
        {

        }
        //  장면 전환기능
        public static void SceneChange(string sceneName)
        {
            //  이동 전에 저장할래용
            prevSceneName = curScene.name;
            curScene.Exit();
            //  이동할게용
            curScene = sceneDic[sceneName];
            curScene.Enter();
        }

    }
}
