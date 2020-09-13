using System;
using Engine.Particles;
using Engine.Driver.Projectile;
using Engine.Simulations;

namespace Engine.Driver.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // var simulator = new ProjectileSimulator();
            // ProjectileDriver.Simulate(simulator);
            var simulator = new SpringSimulationDriver();
            simulator.Simulate();
        }
    }
}
