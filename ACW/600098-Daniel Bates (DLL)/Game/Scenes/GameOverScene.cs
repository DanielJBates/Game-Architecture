using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using EngineLibrary.Scenes;
using EngineLibrary.Managers;


namespace OpenGL_Game.Game.Scenes
{
    class GameOverScene : Scene
    {
        public static GameOverScene GameOverInstance;
        public GameOverScene(SceneManager sceneManager) : base(sceneManager)
        {
            GameOverInstance = this;
            // Set the title of the window
            sceneManager.Title = "Maze Escape - Game Over";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;
        }

        public override void Update(FrameEventArgs e)
        {
            inputManager.ProcessInputs(SceneTypes.SCENE_GAME_OVER);
        }

        public override void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Width, 0, sceneManager.Height, -1, 1);

            GUI.clearColour = Color.Red;

            //Display the Title
            float width = sceneManager.Width, height = sceneManager.Height, fontSize = Math.Min(width, height) / 10f;
            GUI.Label(new Rectangle(0, (int)(fontSize / 2f), (int)width, (int)(fontSize * 3f)), "GAME OVER MAN, GAME OVER!!!", (int)fontSize, StringAlignment.Center);

            GUI.Render();
        }

        public override void Close()
        {
        }
    }
}