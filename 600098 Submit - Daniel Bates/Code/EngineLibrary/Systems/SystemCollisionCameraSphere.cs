using System.Collections.Generic;
using OpenTK;
using EngineLibrary.Components;
using EngineLibrary.Objects;
using EngineLibrary.Scenes;
using EngineLibrary.Managers;

namespace EngineLibrary.Systems
{
    public class SystemCollisionCameraSphere : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_TRANSFORM | ComponentTypes.COMPONENT_COLLISION_SPHERE);

        CollisionManager collisionManager;
        Camera camera;

        public SystemCollisionCameraSphere(CollisionManager collisionManager, Camera camera)
        {
            this.collisionManager = collisionManager;
            this.camera = camera;
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
                ComponentTransform transform = (ComponentTransform)transformComponent;

                IComponent collisionSphereComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_COLLISION_SPHERE;
                });
                ComponentCollisionSphere collisionSphere = (ComponentCollisionSphere)collisionSphereComponent;

                Collision(entity, transform, collisionSphere);
            }
        }

        public void Collision(Entity entity, ComponentTransform transform, ComponentCollisionSphere collisionSphere)
        {
            if ((transform.Position - camera.cameraPosition).Length < collisionSphere.Radius + camera.radius)
            {
                collisionManager.CollisionWithCamera(entity, CollisionTypes.SPHERE_SPHERE);
            }
        }

        public string Name
        {
            get { return "SystemCollision"; }
        }
    }
}
