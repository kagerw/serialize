using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialize
{
    [Serializable()]
    class targetClass
    {
        int _aaa;
        int _bbb;
        InnnerClass aaa = new InnnerClass();
        public targetClass(int a,int b)
        {
            _aaa = a;
            _bbb = b;
        }
        public override string ToString()
        {
            return String.Format("a is {0} b is {1} innner Class {2}", _aaa, _bbb,aaa.ToString());
        }
    }
    [Serializable()]
    class InnnerClass
    {
        int a = 1;
        int b = 2;
        public override string ToString()
        {
            return String.Format("a is {0} b is {1}", a, b);
        }
    }
}
