using System.Collections.Generic;
using Engine.Common;
using Engine.Driver;
using Engine.ForceGenerators;
using Engine.Interfaces;
using Engine.Particles;
using Engine.SimulationControllers;

namespace Engine.Simulations
{
    public class SpringSimulationDriver
    {
        public void Simulate()
        {
            Particle particle = new Particle();
            particle.setPostition(Vector.Zero());
            particle.setVelocity(new Vector(10,0,0));
            particle.setMass(10);

            //Initialise spring
            Vector anchorPosition = Vector.Zero();
            double restLength = 0;
            double k = 10;

            IForceGenerator generator = new AnchoredSpringGenerator(anchorPosition,k,restLength);
            
            
            //Setup controller
            SimulationController controller = new SimulationController();
            controller.setTimeLimit(50);

            //Setup Simulator
            var simulator = new Simulator(particle,controller);
            simulator.addForceGenerator(generator);
            var simulation = simulator.Simulate();
            string filePath = "./visualizations/spring-sims.json";
            simulator.SaveToJson(filePath,simulation);
        }
    }
}