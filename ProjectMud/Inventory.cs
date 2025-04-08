using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMud.GameObject;

namespace ProjectMud
{
    public class Inventory
    {   //  아이템을 리스트로 관리할래요
        private List<Item> items;
        //  스텍으로 메뉴를 관리할래요.
        private Stack<string> stack;
        private int selectIndex;
        private ConsoleKey input;

        public Inventory()
        {
            items = new List<Item>();
            stack = new Stack<string>();
        }

        public void Add(Item item)
        {
            items.Add(item);
        }
        public void Remove(Item item)
        {
            items.Remove(item);
        }
        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }
        public void UseAt(int index)
        {
            items[index].Use();
        }
        public void Open()
        {
            stack.Push("Menu");
            while (stack.Count > 0)
            {
                Console.Clear();
                switch (stack.Peek())
                {
                    case "Menu":        Menu();         break;
                    case "UseMenu":     UseMenu();      break;
                    case "DropMenu":    DropMenu();     break;
                    case "UseConfrim":  UseConfrim();   break;
                    case "DropConfrim": DropConfrim();  break;
                }

            }
        }

        private void DropConfrim()
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine("{0} 을 버리시겠습니까?");
            Console.WriteLine("1. 버린다.");
            Console.WriteLine("2. 버리지 않는다.");
            input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    selectItem.Use();
                    Util.PressKey("");
                    Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.D2:
                    stack.Pop();
                    break;
             }
        }

        private void UseConfrim()
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine("{0} 을 사용하시겠습니까?");
            Console.WriteLine("1. 사용한다.");
            Console.WriteLine("2. 사용하지 않는다.");
            input = Console.ReadKey(true).Key;
            
            switch (input)
            {
                case ConsoleKey.D1:
                    selectItem.Use();
                    Util.PressKey("");
                    Remove(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.D2:
                    stack.Pop();
                    break;
            }
        }

        private void DropMenu()
        {
            PrintAllItems();
            Console.WriteLine("버리려는 아이템을 고르시오.");
            Console.WriteLine("0을 눌러서 뒤로가기");

            input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D0)
            { stack.Pop(); }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || items.Count <= select)
                {
                    Util.PressKey("범위 내 아이템을 고르시오.");
                }
                else
                {
                    selectIndex = select;
                    stack.Push("DropConfrim");
                }
            }
        }

        private void UseMenu()
        {
            PrintAllItems();
            Console.WriteLine("사용할 아이템을 선택");
            Console.WriteLine("0을 눌러서 뒤로가기");

            input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D0)
            {
                stack.Pop();
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || items.Count <= select)
                {
                    Util.PressKey("범위 내 아이템을 고르시오.");
                }
                else
                {
                    selectIndex = select;
                    stack.Push("UseConfrim");
                }
            }
        }

        private void Menu()
        {
            PrintAllItems();
            Console.WriteLine("1. 사용");
            Console.WriteLine("2. 버리기");
            Console.WriteLine("0. 뒤로가기");

            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    stack.Push("UseMenu");
                    break;
                case ConsoleKey.D2:
                    stack.Push("DropMenu");
                    break;
                case ConsoleKey.D0:
                    stack.Pop();
                    break;
            }
        }


        public void PrintAllItems()
        {
            Console.WriteLine("소유한 아이템");
            if(items.Count == 0)
            {
                Console.WriteLine("가방이 텅 비었다...");
            }
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, items[i].name);
            }
            Console.WriteLine("==========");
        }
    }
}
