using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using EngineLibrary.Managers;
using EngineLibrary.OBJLoader;

namespace EngineLibrary.Components
{
    public abstract class ComponentShader : IComponent
    {
        protected Camera Camera;
        public int pgmID;
        public ComponentShader(string vertexShaderName, string fragmentShaderName, Camera camera)
        {
            Camera = camera;

            pgmID = GL.CreateProgram();
            GL.AttachShader(pgmID, ResourceManager.LoadShader(vertexShaderName, ShaderType.VertexShader));
            GL.AttachShader(pgmID, ResourceManager.LoadShader(fragmentShaderName, ShaderType.FragmentShader));
            GL.LinkProgram(pgmID);
            Console.WriteLine(GL.GetProgramInfoLog(pgmID));
        }

        public abstract void ApplyShader(Matrix4 model, Geometry geometry);

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_SHADER; }
        }
    }
}