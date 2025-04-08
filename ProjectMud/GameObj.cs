using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud
{
    //  추상 클래스
    public abstract class GameObj : Interacts
    {
        public ConsoleColor color;
        public char symbol;
        public Vectors pos;
        public bool isOnece;

        public GameObj(ConsoleColor color, char symbol, Vectors pos, bool isOnece)
        {
            this.color = color;
            this.symbol = symbol;
            this.pos = pos;
            this.isOnece = isOnece;
        }

        public void PrintObj()
        {
            Console.SetCursorPosition(pos.x,pos.y);
            Console.ForegroundColor = color;
            Console.Write(symbol);
            Console.ResetColor();
        }
        public abstract void Interact(Player player);
        
    }
}
