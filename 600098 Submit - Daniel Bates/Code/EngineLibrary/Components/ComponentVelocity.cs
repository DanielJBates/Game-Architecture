﻿using OpenTK;

namespace EngineLibrary.Components
{
    public class ComponentVelocity : IComponent
    {
        Vector3 velocity;

        public ComponentVelocity(float x, float y, float z)
        {
            velocity = new Vector3(x, y, z);
        }

        public ComponentVelocity(Vector3 pVelocity)
        {
            velocity = pVelocity;
        }

        public Vector3 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_VELOCITY; }
        }
    }
}
