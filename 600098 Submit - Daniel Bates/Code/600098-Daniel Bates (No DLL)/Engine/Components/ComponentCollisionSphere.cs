﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenGL_Game.Components
{
    class ComponentCollisionSphere : IComponent
    {
        float radius;

        public ComponentCollisionSphere(float radius)
        {
            this.radius = radius;
        }

        public float Radius
        {
            get { return this.radius; }
            set { radius = value; }
        }

        public ComponentTypes ComponentType 
        {
            get { return ComponentTypes.COMPONENT_COLLISION_SPHERE; }
        }
    }
}
