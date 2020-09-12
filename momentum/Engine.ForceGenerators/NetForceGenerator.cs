using System.Collections.Generic;
using Engine.Common;
using Engine.Interfaces;
using Engine.Particles;

namespace Engine.ForceGenerators
{
    public class ForceRegistry
    {
        private Dictionary<IForceGenerator,Particle> Registry { get; set; }
        public ForceRegistry()
        {
            Registry = new Dictionary<IForceGenerator, Particle>();
        }

        public void addToRegistry(IForceGenerator generator,Particle particle)
        {
            Registry.Add(generator,particle);
        }

        public void applyNetForce(double tick)
        {
            foreach(KeyValuePair<IForceGenerator,Particle> pair in Registry)
            {
                var mass = pair.Value;
                pair.Key.applyForce(ref mass,tick);
            }
        }

        
    }
}