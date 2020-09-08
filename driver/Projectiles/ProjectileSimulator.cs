using Engine.Particles;
using Engine.Common;
using Engine.Driver.Utilities;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Engine.ForceGenerators;

namespace Engine.Driver.Projectile
{
    public class ProjectileSimulator
    {
        public Particle projectile = null;

        public void InitialiseProjectile()
        {
            projectile = new Particle();
            var initialPosition = new Vector(0,0,0);
            
            projectile.setPostition(initialPosition);            
            var initialVelocity = Vector.GetVectorFromPolarForm(75,Math.PI/3);
            projectile.setVelocity(initialVelocity);
            var g = new Vector(0,-10,0);
            projectile.setAcceleration(Constants.AccelerationDueToGravity);
            projectile.forceAccum = Vector.Zero();
            projectile.setMass(10);

        }

        public ProjectileSimulation Simulate()
        {
            ProjectileSimulation simulation = new ProjectileSimulation();
            simulation.InitialVelocity = projectile.velocity;
            var positionWithTime = new List<Snapshot>();
            double startTime = 0f;
            //double endtime = 10f;
            double tick = Utils.GetTickFromFPS(20);
            var forceGenerator = new GravityForceGenerator();
            while(projectile.position.y>=0)
            {
                var snapshot = new Snapshot(projectile.position,startTime);
                positionWithTime.Add(snapshot);
                //forceGenerator.applyForce(ref projectile,projectile.mass);
                projectile.forceAccum = new Vector(0,0,0);
                projectile.Integrate(tick);
                startTime+=tick;
            }
            simulation.Snapshots = positionWithTime;
            return simulation;
        }

        public void SaveSimulationToJson(string fileName,ProjectileSimulation simulation)
        {
            string json = JsonConvert.SerializeObject(simulation);
            fileName = "./simulations/"+fileName;
            File.WriteAllText(fileName,json);

        }


    }

    
}