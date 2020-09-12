using Engine.Common;

namespace Engine.SimulationControllers
{
    public class ParticleState
    {
        public Vector Location { get; set; }
        public Vector Velocity { get; set; }
        public Vector Acceleration { get; set; }
        public double Mass { get; set; }
        public double Time { get; set; }

    }
}