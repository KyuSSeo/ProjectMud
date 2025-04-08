using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMud
{
    //  하위 장면 구현을 위한 추상 클래스 선언
    public abstract class Scene
    {
        public string name;

        //  반드시 구현
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Result();

        //  가상함수로 구현 여부 선택
        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}
