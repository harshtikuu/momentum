using Engine.Particles;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Engine.Driver
{
    public class ProjectileSimulator
    {
        public Particle projectile = null;

        public void InitialiseProjectile()
        {
            projectile = new Particle();
            var initialPosition = new Vector(0,0,0);
            
            projectile.setPostition(initialPosition);
            
            var initialVelocity = GetVectorFromPolarForm(30,Math.PI/4);
            projectile.setVelocity(initialVelocity);

            var g = new Vector(0,-10,0);
            projectile.setAcceleration(g);

            projectile.setMass(10);

        }

        public List<Snapshot> Simulate()
        {
            var positionWithTime = new List<Snapshot>();
            double startTime = 0f;
            double endtime = 10f;
            double tick = GetTickFromFPS(20);

            while(startTime<endtime)
            {
                var snapshot = new Snapshot(projectile.position,startTime);
                positionWithTime.Add(snapshot);
                projectile.forceAccum = new Vector(0,0,0);
                projectile.Integrate(tick);
                startTime+=tick;
            }

            return positionWithTime;
        }

        public void SaveSimulationToJson(string fileName,List<Snapshot> simulation)
        {
            string json = JsonConvert.SerializeObject(simulation);
            File.WriteAllText(fileName,json);

        }

        private Vector GetVectorFromPolarForm(double r, double theta)
        {
            var vector = new Vector();
            vector.x = (double)(r*Math.Cos(theta));
            vector.y = (double)(r*Math.Sin(theta));

            return vector;
        }

        private double GetTickFromFPS(int fps)
        {
            if (fps>0)
                return 1.0/fps;
            else
                throw new DivideByZeroException();
        }


    }

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
}