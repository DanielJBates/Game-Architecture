using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EngineLibrary.Scenes;

namespace EngineLibrary.Managers
{
    public abstract class InputManager
    {
        abstract public void ProcessInputs(SceneTypes sceneType);
    }
}
