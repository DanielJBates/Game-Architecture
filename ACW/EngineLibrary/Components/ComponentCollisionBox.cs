using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using EngineLibrary.Components;

namespace EngineLibrary.Engine.Components
{
    public class ComponentCollisionBox : IComponent
    {
        Vector3[] points = new Vector3[8];

        public ComponentCollisionBox(Vector3[] points)
        {
            this.points = points;
        }
        public ComponentCollisionBox(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, Vector3 P4, Vector3 P5, Vector3 P6, Vector3 P7)
        {
            this.points[0] = P0;
            this.points[1] = P1;
            this.points[2] = P2;
            this.points[3] = P3;
            this.points[4] = P4;
            this.points[5] = P5;
            this.points[6] = P6;
            this.points[7] = P7; 
        }

        public Vector3[] Points
        {
            get { return points; }
            set { points = value; }
        }
        public Vector3 P0
        {
            get { return points[0]; }
            set { points[0] = value; }
        }
        public Vector3 P1
        {
            get { return points[1]; }
            set { points[1] = value; }
        }
        public Vector3 P2
        {
            get { return points[2]; }
            set { points[2] = value; }
        }
        public Vector3 P3
        {
            get { return points[3]; }
            set { points[3] = value; }
        }
        public Vector3 P4
        {
            get { return points[4]; }
            set { points[4] = value; }
        }
        public Vector3 P5
        {
            get { return points[5]; }
            set { points[5] = value; }
        }
        public Vector3 P6
        {
            get { return points[6]; }
            set { points[6] = value; }
        }
        public Vector3 P7
        {
            get { return points[7]; }
            set { points[7] = value; }
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_COLLISION_BOX; }
        }
    }
}
