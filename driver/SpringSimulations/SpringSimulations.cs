using System;
using Engine.ForceGenerators;
using Engine.Common;
using Engine.Particles;
using Engine.Interfaces;
using System.Collections.Generic;
using Engine.Driver.Projectile;
using Engine.Driver.Utilities;
using Newtonsoft.Json;
using System.IO;

namespace Engine.Driver
{
    public class SpringSimulation
    {
        public IForceGenerator forceGenerator{get;set;}
        public Particle mass = null;
        public SpringSimulation()
        {
            mass = new Particle();
            Vector Anchor = Vector.Zero();
            double k = 1;
            double restLength = 0;
            forceGenerator = new AnchoredSpringGenerator(Anchor,k,restLength);
        }

        public void InitialiseParticle()
        {
            mass.setMass(5);
            mass.setAcceleration(Vector.Zero());
            mass.forceAccum = Vector.Zero();
            var initialVelocity = new Vector(10,0,0);
            mass.setPostition(new Vector(0,0,0));
            mass.setVelocity(initialVelocity);
            mass.forceAccum = Vector.Zero();
            mass.setAcceleration(getAcceleration(mass));
            
        }

        public Vector getAcceleration(Particle mass)
        {
            double k = 5;
            var force = -(mass.position*k);
            var acc = force*mass.inverseMass;
            return acc;
        }

        public List<Snapshot> Simulate()
        {
            var response = new List<Snapshot>();
            InitialiseParticle();
            double startTime = 0;
            double EndTime = 50;
            double tick = Utils.GetTickFromFPS(60);

            while(startTime<EndTime)
            {
                var snapshot = new Snapshot(this.mass.position,startTime);
                response.Add(snapshot);
                mass.setAcceleration(getAcceleration(mass));
                //forceGenerator.applyForce(ref mass,tick);
                mass.Integrate(tick);
                startTime+=tick;
            }

            return response;   
        }

        public void SaveToJson(List<Snapshot> sims,string fileName)
        {
            string json = JsonConvert.SerializeObject(sims);
            fileName = "./simulations/"+fileName;
            File.WriteAllText(fileName,json);
        }


    }
}