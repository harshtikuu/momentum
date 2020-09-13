using Engine.Common;
using Engine.Interfaces;
using Engine.Particles;
using System;

namespace Engine.ForceGenerators
{
    public class FrictionalForceGenerator : IForceGenerator
    {
        protected double mu{get;set;}
        public FrictionalForceGenerator(double frictionCoeff)
        {
            this.mu = frictionCoeff;
        }
        public void applyForce(ref Particle particle, double tick)
        {
            Vector normalForce = Constants.AccelerationDueToGravity*particle.mass;
            double magnitude = normalForce.magnitude()*mu;
            Vector direction = -particle.velocity.getUnitVector();
            Vector frictionalForce = direction*magnitude;
            particle.AddForce(frictionalForce); 
        }
    }
}