using Engine.Common;
using Engine.Particles;

namespace Engine.Driver
{
    public class BasicInitiliaser : IParticleInitialiser
    {
        public Particle Initialise(Vector initPosition,Vector initVelocity,double mass)
        {
            Particle particle = new Particle();
            particle.setPostition(initPosition);
            particle.setVelocity(initVelocity);
            particle.setMass(mass);
            return particle;
        }
    }
}