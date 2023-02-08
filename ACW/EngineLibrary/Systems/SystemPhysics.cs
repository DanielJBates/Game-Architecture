using System.Collections.Generic;
using OpenTK;
using EngineLibrary.Components;
using EngineLibrary.Objects;
using EngineLibrary.Scenes;

namespace EngineLibrary.Systems
{
    public class SystemPhysics : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_TRANSFORM | ComponentTypes.COMPONENT_VELOCITY);

        public string Name
        {
            get { return "SystemPhysics"; }
        }

        public void OnAction(Entity entity)
        {
            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent transformComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                });

                IComponent velocityComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_VELOCITY;
                });

                Motion(((ComponentTransform)transformComponent), ((ComponentVelocity)velocityComponent));
            }
        }

        public void Motion(ComponentTransform transform, ComponentVelocity velocity)
        {
            transform.Position += velocity.Velocity * Scene.dt;
        }
    }
}

