using System;
using Engine.Common;
using Engine.Interfaces;
using Engine.Particles;

namespace Engine.ForceGenerators
{
    public class GravityForceGenerator : IForceGenerator
    {
        public Vector accDueToGravity = Constants.AccelerationDueToGravity;
        public void applyForce(ref Particle particle, double tick)
        {
            Vector force = accDueToGravity*particle.mass;
            particle.AddForce(force);
        }
        
    }
    

}
