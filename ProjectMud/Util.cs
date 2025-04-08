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
            //  TODO : 플레이어 스텟을 구현한 뒤 셋 포지션 기능을 이용해 플레이어 정보 및 기본 메뉴를 띄우고 싶다.

            Console.SetCursorPosition(0, 10);
            Console.WriteLine("*********************************");
            Console.WriteLine();
        }
    }   
}
