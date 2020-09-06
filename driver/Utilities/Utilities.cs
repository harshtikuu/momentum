using System;

namespace Engine.Driver.Utilities
{
    public class Utils
    {
        public static double GetTickFromFPS(int fps)
        {
            if (fps>0)
                return 1.0/fps;
            else
                throw new DivideByZeroException();
        }
    }
}