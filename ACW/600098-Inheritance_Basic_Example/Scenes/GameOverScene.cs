﻿using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using OpenGL_Game.Managers;

namespace OpenGL_Game.Scenes
{
    class GameOverScene : Scene
    {
        public GameOverScene(SceneManager sceneManager) : base(sceneManager)
        {
            // Set the title of the window
            sceneManager.Title = "Game Over";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;

            // Set Keyboard events to go to a method in this class
            sceneManager.keyboardUpDelegate += Keyboard_KeyUp;
        }

        public override void Update(FrameEventArgs e)
        {
        }

        public override void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Width, 0, sceneManager.Height, -1, 1);

            GUI.clearColour = Color.DarkGreen;

            //Display the Title
            float width = sceneManager.Width, height = sceneManager.Height, fontSize = Math.Min(width, height) / 10f;
            GUI.Label(new Rectangle(0, (int)(fontSize / 2f), (int)width, (int)(fontSize * 2f)), "Game Over", (int)fontSize, StringAlignment.Center);

            GUI.Render();
        }

        public void Keyboard_KeyUp(KeyboardKeyEventArgs e)
        {
            sceneManager.ChangeScene(SceneTypes.SCENE_MAIN_MENU);
        }

        public override void Close()
        {
            sceneManager.keyboardUpDelegate -= Keyboard_KeyUp;
        }
    }
}