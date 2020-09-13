using System;
using Engine.Particles;
//using Engine.SimulationModels.Projectile;
using Engine.Simulators;

namespace Engine.SimulationModels.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // var simulator = new ProjectileSimulator();
            // ProjectileDriver.Simulate(simulator);
            var simulator = new SpringSimulator();
            simulator.Simulate();
        }
    }
}
