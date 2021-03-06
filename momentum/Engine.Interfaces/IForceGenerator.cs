﻿using Engine.Common;
using Engine.Particles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Interfaces
{
    public interface IForceGenerator
    {
        void applyForce(ref Particle particle, double tick);
    }
}
