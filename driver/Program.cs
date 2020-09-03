using System;
using Engine.Particles;
namespace Engine.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1,2,3);
            Vector v2 = new Vector(1,1,0);
            var v3 = v1+v2;
            Console.WriteLine(v3.getHatNotation());
        }
    }
}
