using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Engine.Objects;
using OpenTK;

namespace OpenGL_Game.Game.Objects
{
    class MazeEscapePlayer : Player
    {
        int lives = 3;
        int keycards = 0;

        public MazeEscapePlayer(Camera Camera) : base(Camera)
        { }

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
        public int Keycards
        {
            get { return keycards; }
            set { keycards = value; }
        }
    }
}
