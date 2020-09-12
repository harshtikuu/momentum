using Engine.Particles;
using Engine.Common;

namespace Engine.Driver
{
    public interface IParticleInitialiser
    {
        Particle Initialise(Vector initPosition,Vector initVelocity,double mass);
    }
}