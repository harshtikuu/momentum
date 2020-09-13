namespace Engine.SimulationModels
{
    public class SpringDriver
    {
        public static void Simulate()
        {
            var simulator = new SpringSimulation();
            var response = simulator.Simulate();
            var fileName = "springSimulation.json";
            simulator.SaveToJson(response,fileName);
        }
    }
}