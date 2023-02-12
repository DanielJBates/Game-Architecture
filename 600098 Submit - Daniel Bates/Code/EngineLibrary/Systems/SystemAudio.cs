using System.Collections.Generic;
using OpenTK;
using EngineLibrary.Components;
using EngineLibrary.Objects;
using EngineLibrary.Scenes;

namespace EngineLibrary.Systems
{
    public class SystemAudio : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_TRANSFORM | ComponentTypes.COMPONENT_AUDIO);
       
        public SystemAudio()
        {
        }
        public void OnAction(Entity entity)
        {
            List<IComponent> components = entity.Components;

            if ((entity.Mask & MASK) == MASK)
            {
                IComponent transformComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                });
                Vector3 position = ((ComponentTransform)transformComponent).Position;
                Matrix4 model = ((ComponentTransform)transformComponent).Identity;

                IComponent audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });
                ((ComponentAudio)audioComponent).SetPosition(position);
            }
        }
        public string Name
        {
            get { return "SystemAudio"; }
        }
    }
}
