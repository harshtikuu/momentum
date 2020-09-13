using System.Collections.Generic;
using Engine.Common;
using Engine.SimulationModels;
using Engine.ForceGenerators;
using Engine.Interfaces;
using Engine.Particles;
using Engine.SimulationControllers;

namespace Engine.Simulators
{
    public class SpringSimulator
    {
        public void Simulate()
        {
            Particle particle = new Particle();
            particle.setPostition(Vector.Zero());
            particle.setVelocity(new Vector(50,0,0));
            particle.setMass(20);

            //Initialise spring
            Vector anchorPosition = Vector.Zero();
            double restLength = 0;
            double k = 10;

            IForceGenerator generator = new AnchoredSpringGenerator(anchorPosition,k,restLength);
            IForceGenerator friction = new FrictionalForceGenerator(0.1);
            
            
            //Setup controller
            SimulationController controller = new SimulationController();
            controller.setTimeLimit(100);

            //Setup Simulator
            var simulator = new Simulator(particle,controller);
            simulator.addForceGenerator(generator);
            simulator.addForceGenerator(friction);
            var simulation = simulator.Simulate();
            string filePath = "./visualizations/spring-sims.json";
            simulator.SaveToJson(filePath,simulation);
        }
    }
}