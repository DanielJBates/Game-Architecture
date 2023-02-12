using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Scenes;

namespace OpenGL_Game.Engine.Managers
{
    abstract class InputManager
    {
        abstract public void ProcessInputs(SceneTypes sceneType);
    }
}
