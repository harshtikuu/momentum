using System;
using Engine.Particles;
namespace Engine.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            var simulator = new ProjectileSimulator();
            ProjectileDriver.Simulate(simulator);
        }
    }
}
