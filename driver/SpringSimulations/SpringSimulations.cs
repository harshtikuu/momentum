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
            
        }

        public List<Snapshot> Simulate()
        {
            var response = new List<Snapshot>();
            InitialiseParticle();
            double startTime = 0;
            double EndTime = 10;
            double tick = Utils.GetTickFromFPS(1);

            while(startTime<EndTime)
            {
                var snapshot = new Snapshot(this.mass.position,startTime);
                response.Add(snapshot);
                forceGenerator.applyForce(ref mass,tick);
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