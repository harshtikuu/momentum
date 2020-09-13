namespace Engine.SimulationControllers
{

    public interface ISimulationController
    {
         bool endSimulation(ParticleState particleState);
    }


    public class SimulationController:ISimulationController
    {
        public double timeLimit { get; protected set; }
        
        public void setTimeLimit(double timeLimit)
        {
            this.timeLimit = timeLimit;
        }

        public bool endSimulation(ParticleState particleState)
        {
            if(particleState.Time>timeLimit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}