using System;
using System.Collections.Generic;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using EngineLibrary.Components;
using EngineLibrary.OBJLoader;
using EngineLibrary.Objects;
using EngineLibrary.Scenes;

namespace EngineLibrary.Systems
{
    public class SystemRender : ISystem
    {
        const ComponentTypes MASK = (ComponentTypes.COMPONENT_TRANSFORM | ComponentTypes.COMPONENT_GEOMETRY | ComponentTypes.COMPONENT_SHADER);

        public SystemRender()
        {
        }

        public string Name
        {
            get { return "SystemRender"; }
        }

        public void OnAction(Entity entity)
        {
            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent geometryComponent = components.Find(delegate(IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_GEOMETRY;
                });
                Geometry geometry = ((ComponentGeometry)geometryComponent).Geometry();

                IComponent  transformComponent = components.Find(delegate(IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                });
                Matrix4 model = ((ComponentTransform)transformComponent).Identity;

                IComponent shaderComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_SHADER;
                });
                ComponentShader shader = (ComponentShader)shaderComponent;

                Draw(model, geometry, shader);
            }
        }

        public void Draw(Matrix4 model, Geometry geometry, ComponentShader shaderComponent)
        {
            shaderComponent.ApplyShader(model, geometry);
        }
    }
}
