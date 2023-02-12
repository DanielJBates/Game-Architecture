using System;
using EngineLibrary.Managers;
using OpenGL_Game.Game.Scenes;

namespace OpenGL_Game
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class MainEntry
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SceneManager game = new SceneManager();
            game.SetOnLoadScene = new MainMenuScene(game);
                game.Run();
        }
    }
#endif
}
