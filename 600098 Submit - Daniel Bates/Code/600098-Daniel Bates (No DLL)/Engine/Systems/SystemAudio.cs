using System.Collections.Generic;
using OpenTK;
using OpenGL_Game.Components;
using OpenGL_Game.Engine.Components;
using OpenGL_Game.Objects;
using OpenGL_Game.Scenes;

namespace OpenGL_Game.Systems
{
    class SystemAudio : ISystem
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
