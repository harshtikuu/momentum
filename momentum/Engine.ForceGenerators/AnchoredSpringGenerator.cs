using Engine.Common;
using Engine.Interfaces;
using Engine.Particles;

namespace  Engine.ForceGenerators
{
    public class AnchoredSpringGenerator : IForceGenerator
    {
        public Vector Anchor { get; set; }
        public double K{get;set;} //springs constant for the spring
        public double RestLength { get; set; }
        public AnchoredSpringGenerator(Vector anchorPosition,double k,double restLength)
        {
            Anchor = anchorPosition;
            K = k;
            RestLength = restLength;
        }

        public void applyForce(ref Particle particle, double tick)
        {
            Vector forceDirection = -particle.position.getUnitVector();
            double sprintStrechLength = particle.position.magnitude()-RestLength;
            double forceMagnitude = K*sprintStrechLength;
            Vector springForce = forceDirection*forceMagnitude;
            particle.AddForce(springForce);            
        }
    }
}