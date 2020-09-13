namespace Engine.SimulationModels.Projectile
{
    public class ProjectileDriver
    {
        public static void Simulate(ProjectileSimulator simulator)
        {
            simulator.InitialiseProjectile();
            var simulation = simulator.Simulate();
            var fileName = "projectile-sim.json";
            simulator.SaveSimulationToJson(fileName,simulation);
        }
    }
}