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

        //  시작기능
        public static void Start()
        {
            gameEnd = false;

            sceneDic = new Dictionary<string, Scene>();
            sceneDic.Add("Title", new Title());
            sceneDic.Add("Test01", new Test01());
            sceneDic.Add("Test02", new Test02());
            sceneDic.Add("Test03", new Test03());

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
            curScene = sceneDic[sceneName];
        }

    }
}
