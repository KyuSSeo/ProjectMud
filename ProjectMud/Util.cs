using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud
{
   public class Util
    {
        public static void PressKey(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("진행하려면 아무 키나 입력해 주세요...");
            Console.ReadKey(true);
        }
        public static void TextLine()
        {
            //아래쪽에다가 출력할래요
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("*********************************");
            Console.WriteLine();
        }
    }   
}
