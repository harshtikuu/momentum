using System;
using Engine.Common;
using Engine.ForceGenerators;
using Engine.Particles;
using Engine.SimulationControllers;
using Engine.SimulationModels;
namespace Engine.Simulators
{
    public class ProjectileSimulator
    {
        public void Simulate()
        {
            //Initialise Particle
            Particle projectile = new Particle();
            projectile.setPostition(Vector.Zero());
            projectile.setVelocity(Vector.GetVectorFromPolarForm(10,(Math.PI/4)));
            projectile.setMass(5);

            //Initiliase Simulation Controller
            var simController = new ProjectileSimulationController();

            //Initialise Simulator
            var simulator = new Simulator(projectile,simController);
            simulator.addForceGenerator(new GravityForceGenerator());
            var simulation = simulator.Simulate();
            string filePath = "./visualizations/projectile-sim.json";
            simulator.SaveToJson(filePath,simulation);

        }
    }
    public class ProjectileSimulationController : ISimulationController
    {
        public bool endSimulation(ParticleState particleState)
        {
            if(particleState.Location.y<0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}