using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DIContainer_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Project");
            var container = new UnityContainer();

            Console.WriteLine("RegisterType Start");
            container.RegisterType<IA, A>();
            container.RegisterType<IB, B>();
            container.RegisterType<IC, C>();
            Console.WriteLine("RegisterType End");

            var obj = container.Resolve<Object>();
            obj.Do();

            Console.WriteLine("===== obj2 =====");
            container.RegisterType<IA, ATest>();
            var obj2 = container.Resolve<Object>();
            obj2.Do();
        }
    }
}

class Object
{
    public IA a;
    public IB b;
    public IC c;
    public Object(IA a, IB b, IC c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void Do()
    {
        a.DoA(); b.DoB(); c.DoC();
    }
}

interface IA { void DoA(); }
interface IB { void DoB(); }
interface IC { void DoC(); }

class A : IA
{
    public A() { Console.WriteLine("A()"); }
    public void DoA() { Console.WriteLine("A-DoA()"); }
}
class B : IB
{
    public B() { Console.WriteLine("B()"); }
    public void DoB() { Console.WriteLine("B-DoB()"); }
}
class C : IC
{
    public C() { Console.WriteLine("C()"); }
    public void DoC() { Console.WriteLine("C-DoC()"); }
}

class ATest : IA
{
    public ATest() { Console.WriteLine("ATest()"); }
    public void DoA() { Console.WriteLine("ATest-DoA()"); }
}
