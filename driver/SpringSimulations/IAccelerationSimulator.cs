using Engine.Common;
using Engine.Particles;

namespace Engine.Driver
{
    public interface IAccelerationSimulator
    {
        Vector getAcceleration(Particle particle);
    }
}