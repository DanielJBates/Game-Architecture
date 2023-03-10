using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenGL_Game.Scenes;
using OpenGL_Game.Game.Scenes;
using OpenTK.Audio;

namespace OpenGL_Game.Managers
{
    class SceneManager : GameWindow
    {
        Scene scene;
        public static int width = 1200, height = 800;
        public static int windowXPos = 200, windowYPos = 80;

        public delegate void SceneDelegate(FrameEventArgs e);
        public SceneDelegate renderer;
        public SceneDelegate updater;

        AudioContext audioContext;

        public SceneManager() : base(width, height, new OpenTK.Graphics.GraphicsMode(new OpenTK.Graphics.ColorFormat(8, 8, 8, 8), 16))
        {
            this.X = windowXPos;
            this.Y = windowYPos;

            audioContext = new AudioContext();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            //Load the GUI
            GUI.SetUpGUI(width, height);

            StartMenu();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            updater(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            renderer(e);

            GL.Flush();
            SwapBuffers();
        }

        public void StartNewGame()
        {
            if(scene != null) scene.Close();
            scene = new GameScene(this);
        }

        public void StartMenu()
        {
            if (scene != null) scene.Close();
            scene = new MainMenuScene(this);
        }

        public void StartGameOver()
        {
            if (scene != null) scene.Close();
            scene = new GameOverScene(this);
        }
        public void StartGameWin()
        {
            if (scene != null) scene.Close();
            scene = new WinScene(this);
        }

        public void ChangeScene(SceneTypes sceneType)
        {
            if (sceneType == SceneTypes.SCENE_GAME)
            {
                StartNewGame();
            }
            else if (sceneType == SceneTypes.SCENE_MAIN_MENU)
            {
                StartMenu();
            }
            else if (sceneType == SceneTypes.SCENE_GAME_OVER)
            {
                StartGameOver();
            }
            else if (sceneType == SceneTypes.SCENE_WIN)
            {
                StartGameWin();
            }
        }

        public static int WindowWidth
        {
            get { return width; }
        }

        public static int WindowHeight
        {
            get { return height; }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            SceneManager.width = Width;
            SceneManager.height = Height;

            //Load the GUI
            GUI.SetUpGUI(Width, Height);
        }
    }

}

