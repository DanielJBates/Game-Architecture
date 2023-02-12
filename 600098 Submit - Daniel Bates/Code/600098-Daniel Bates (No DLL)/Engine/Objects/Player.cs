using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Objects;
using OpenTK;

namespace OpenGL_Game.Engine.Objects
{
    abstract class Player : Entity
    {
        private Camera camera;

        public Player(Camera Camera) : base("Player")
        {
            camera = Camera;
        }

        public Camera Camera
        {
            get { return camera; }
        }
    }
}
