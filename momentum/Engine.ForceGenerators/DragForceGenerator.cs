using System;
using System.Collections.Generic;
using System.Text;
using Engine.Interfaces;
using Engine.Particles;
using Engine.Common;

namespace Engine.ForceGenerators
{
    public class DragForceGenerator : IForceGenerator
    {
        public DragForceGenerator(double DragConstant)
        {
            this.DragConstant = DragConstant;
        }
        public double DragConstant { get; set; }
        public void applyForce(ref Particle particle, double tick)
        {
            Vector velocity = particle.velocity;
            double speed = velocity.magnitude();
            double speedSquared = Math.Pow(speed,2);
            double forceMagnitude = DragConstant*speedSquared;
            Vector dragForce = -velocity.getUnitVector();
            dragForce = dragForce*forceMagnitude;
            particle.AddForce(dragForce);
        }
    }
}
