﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud
{
    public class Util
    {

        //  키 입력대기
        public static void PressKey(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("진행하려면 아무 키나 입력해 주세요...");
            Console.ReadKey(true);
        }


        //  상호작용용 UI 
        public static void InteractText(string text)
        {
            Console.SetCursorPosition(0, 13);
            Console.WriteLine("*********************");
            Console.WriteLine(text);
            Thread.Sleep(500);
            Console.ReadKey(true);
            
        }
    }   
}
