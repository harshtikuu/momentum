using System;
using System.Collections.Generic;
using System.Text;
using Engine.Common;
using Engine.Interfaces;
using Engine.Particles;

namespace Engine.ForceGenerators
{
    public class BuoyancyForceGenerator : IForceGenerator
    {
        public BuoyancyForceGenerator(double volume,double fluidDensity,double fluidlevel)
        {
            this.Volume = volume;
            this.fluidDensity = fluidDensity;
            this.fluidHeight = fluidlevel;
        }
        public double Volume { get; set; }
        public double fluidDensity { get; set; }
        public double fluidHeight { get; set; }
        
        public void applyForce(ref Particle particle, double tick)
        {
            Vector force;
            double position = particle.position.y;
            if(position>fluidHeight)
            {
                force = Vector.Zero();
            }
            else 
            {
                force = Constants.AccelerationDueToGravity*(fluidDensity*Volume);
            }
            particle.AddForce(force);
        }
    }
}
