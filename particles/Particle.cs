using System;
using Extensions;

namespace Engine.Particles
{
    public class Particle
    {
        public Vector position {get;protected set;}
        public Vector velocity {get;protected set;}
        public Vector acceleration { get; protected set;}
        public decimal mass
        {
            get
            {
                if(IsMassInfinite)
                {
                    throw new ArgumentOutOfRangeException("Infinte Mass");
                }
                else
                {
                    return this.mass;
                }
            } 
        protected set{}
        }
        public bool IsMassInfinite { get; set; }
        public decimal inverseMass
        {
            get
            {
                if(IsMassInfinite)
                {
                    return 0;
                }

                if(this.mass == 0)
                {
                    throw new DivideByZeroException();
                }
                return (1/this.mass);
            }
            private set{}
        }        
        public Vector forceAccum {get;set;}
        public void Integrate(TimeSpan tick)
        {
            decimal duration = (decimal)tick.TotalSeconds;
            this.acceleration.addScaledVector(this.forceAccum,inverseMass);
            this.forceAccum.clear();

            this.position = this.position.addScaledVector(this.velocity,duration); 
            this.position = this.position.addScaledVector(this.acceleration,duration*duration*0.5M);

            this.velocity = this.velocity.addScaledVector(this.acceleration,duration);

            
        }
        public void setMass(decimal mass)
        {
            this.mass = mass;
        }

        public void setPostition(Vector pos)
        {
            this.position = pos;
        }
        public void setVelocity(Vector v)
        {
            this.velocity = v;
        }

        public void setInfiniteMass()
        {
            this.inverseMass = 0;
            this.IsMassInfinite = true;
        }

        public void setAcceleration(Vector a)
        {
            this.acceleration = a;
        }
    }
}



