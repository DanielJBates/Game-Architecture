using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineLibrary.Objects;
using OpenTK;

namespace EngineLibrary.Objects
{
    public abstract class Player : Entity
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
