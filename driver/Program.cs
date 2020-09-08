using System;
using Engine.Particles;
using Engine.Driver.Projectile;
namespace Engine.Driver.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // var simulator = new ProjectileSimulator();
            // ProjectileDriver.Simulate(simulator);
            SpringDriver.Simulate();
        }
    }
}
