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
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Result();

    }
}
