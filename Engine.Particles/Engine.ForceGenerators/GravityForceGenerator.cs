using System;
using Engine.Common;
using Engine.Interfaces;
using Engine.Particles;

namespace Engine.ForceGenerators
{
    public class GravityForceGenerator : IForceGenerator
    {
        public Vector accDueToGravity = new Vector(0, -9.81, 0);
        public void UpdateForces(ref Particle particle, double tick)
        {
            Vector force = accDueToGravity * particle.mass;
            particle.AddForce(force);
        }
    }

    
    

}
