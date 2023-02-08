using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using EngineLibrary.Components;

namespace EngineLibrary.Components
{
    public class ComponentCollisionLine : IComponent
    {
        Vector3 point0;
        Vector3 point1;

        public ComponentCollisionLine(Vector3 P0, Vector3 P1)
        {
            this.point0 = P0;
            this.point1 = P1;
        }

        public Vector3 P0
        {
            get { return point0; }
            set { point0 = value; }
        }
        public Vector3 P1
        {
            get { return point1; }
            set { point1 = value; }
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_COLLISION_LINE; }
        }
    }
}
