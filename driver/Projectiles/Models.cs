using System;
using System.Collections.Generic;
using Engine.Particles;
namespace Engine.Driver.Projectile
{
    public class Snapshot
    {
        public Vector Location { get; set; }
        public double Time { get; set; }

        public Snapshot(Vector Location,double Time)
        {
            this.Location = Location;
            this.Time = Time;
        }

    }

    public class ProjectileSimulation
    {
        public List<Snapshot> Snapshots { get; set; }
        public Vector InitialVelocity {get;set;}
        public double AngleOfProjection
        {
            get
            {
                if(InitialVelocity.x!=0)
                {
                    return Math.Atan2(InitialVelocity.y,InitialVelocity.x);
                }
                else
                {
                    return Math.PI/2;
                }
            }
        }
    }
}