using System;
using Extensions;

namespace Engine.Particles
{
    public class Particle
    {
        public Vector position {get;protected set;}
        public Vector velocity {get;protected set;}
        public Vector acceleration { get; protected set;}
    
        public double mass { get; protected set; }    
        public double inverseMass { get; protected set; }     
        public Vector forceAccum {get;set;}
        public void Integrate(double tick)
        {
            double duration = (double)tick;
            this.acceleration.addScaledVector(this.forceAccum,inverseMass);
            this.forceAccum.clear();

            this.position = this.position.addScaledVector(this.velocity,duration); 
            this.position = this.position.addScaledVector(this.acceleration,duration*duration*0.5);

            this.velocity = this.velocity.addScaledVector(this.acceleration,duration);

            
        }
        public void setMass(double mass)
        {
            if(mass>0)
            {
                this.mass = mass;
                this.inverseMass = 1.0/mass;
            }
            else
            {
                throw new ArgumentException("Can't set zero or negative mass");
            }
        }

        public void setPostition(Vector pos)
        {
            this.position = pos;
        }
        public void setVelocity(Vector v)
        {
            this.velocity = v;
        }

        public void setAcceleration(Vector a)
        {
            this.acceleration = a;
        }
    }
}



