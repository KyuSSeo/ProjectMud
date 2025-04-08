using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
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
    }   
}
