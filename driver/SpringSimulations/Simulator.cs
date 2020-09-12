using System;
using System.Collections.Generic;
using System.IO;
using Engine.Driver.Projectile;
using Engine.Interfaces;
using Engine.Particles;

using Engine.SimulationControllers;
using Newtonsoft.Json;

namespace Engine.Driver
{
    public class Simulator
    {        
        private Particle particle = null;

        public int FPS{get;protected set;}
        private IEnumerable<IForceGenerator> forceGenerators = null;
        private ISimulationController simulationController= null;
        public Simulator(Particle particle,IEnumerable<IForceGenerator> forceGenerators,ISimulationController simulationController)
        {
            this.particle = particle;
            this.forceGenerators = forceGenerators;
            this.simulationController = simulationController;
            setFPS(60);
            
        }

        private double getTick()
        {
            return 1.0/this.FPS;
        }

        public void setFPS(int fps)
        {
            if (fps>0)
            {
                this.FPS = fps;
            }

            else
            {
                throw new ArgumentException("Frames per second should be a positive integer");
            }
        }

        private void applyForce(double tick)
        {
            foreach(var forceGenerator in forceGenerators)
            {
                forceGenerator.applyForce(ref particle,tick);
            }
        }

        private ParticleState GetParticleState(double time)
        {
            var particleState = new ParticleState()
            {
                Location = this.particle.position,
                Velocity = this.particle.velocity,
                Acceleration = this.particle.acceleration,
                Mass = this.particle.mass,
                Time = time

            };
            return particleState;
        }

        public BasicSimulation Simulate()
        {
            var response = new BasicSimulation();
            double startTime = 0.0;
            double tick = getTick();
            var particleState = this.GetParticleState(startTime);
            var snapshots = new List<ParticleState>();
            while(!simulationController.endSimulation(particleState))
            {
                snapshots.Add(this.GetParticleState(startTime));
                this.applyForce(tick);
                this.particle.Integrate(tick);
                startTime+=tick;
            }
            response.Snapshots = snapshots;
            return response;
        }

        public string SaveToJson(string fileName,BasicSimulation simulation)
        {
            string json = JsonConvert.SerializeObject(simulation);
            fileName = "./simulations/"+fileName;
            File.WriteAllText(fileName,json);
            return fileName;
        }
    }
}