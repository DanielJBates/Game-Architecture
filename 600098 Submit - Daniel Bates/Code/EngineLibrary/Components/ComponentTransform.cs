using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineLibrary.Components;
using OpenTK;

namespace EngineLibrary.Components
{
    struct InitalValues
    {
        public Vector3 initalPosition;
        public Vector3 initalScale;
        public Matrix4 initalRotation;
    }

    public class ComponentTransform : IComponent
    { 
        private InitalValues initals = new InitalValues();
        Vector3 position;
        Vector3 scale;
        Matrix4 rotation;


        public ComponentTransform(Vector3 Position, Matrix4 Rotation, Vector3 Scale)
        {
            position = Position;
            initals.initalPosition = Position;

            rotation = Rotation;
            initals.initalRotation = Rotation;

            scale = Scale;
            initals.initalScale = Scale;
        }

        public Matrix4 Identity
        {
            get { return (rotation * Matrix4.CreateScale(scale) * Matrix4.CreateTranslation(position)); }
        }
        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Matrix4 Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        public Vector3 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public void InitialState()
        {
            position = initals.initalPosition;
            rotation = initals.initalRotation;
            scale = initals.initalScale;
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_TRANSFORM; }
        }
    }
}
