using OpenTK.Input;
using EngineLibrary.Managers;
using EngineLibrary.Scenes;
using OpenGL_Game.Game.Scenes;

namespace OpenGL_Game.Game.Managers
{
    class OpenTKInputManager : InputManager
    {
        public override void ProcessInputs(SceneTypes sceneType)
        {
            switch (sceneType)
            {
                case SceneTypes.SCENE_NONE:
                    break;
                case SceneTypes.SCENE_MAIN_MENU:
                    if (Keyboard.GetState().IsKeyDown(Key.Escape))
                    {
                        MainMenuScene.MainMenuInstance.sceneManager.Exit();
                    }
                    if (Mouse.GetState().IsButtonDown(MouseButton.Left))
                    {
                        MainMenuScene.MainMenuInstance.sceneManager.ChangeScene(new GameScene(MainMenuScene.MainMenuInstance.sceneManager));
                    }
                    break;
                case SceneTypes.SCENE_GAME:
                    if (Keyboard.GetState().IsKeyDown(Key.Escape))
                    {
                        GameScene.gameInstance.sceneManager.Exit();
                    }
                    if (Keyboard.GetState().IsKeyDown(Key.Up) || Keyboard.GetState(0).IsKeyDown(Key.W))
                    {
                        GameScene.gameInstance.player.Camera.MoveForward(0.1f);
                    }
                    if (Keyboard.GetState().IsKeyDown(Key.Down) || Keyboard.GetState(0).IsKeyDown(Key.S))
                    {
                        GameScene.gameInstance.player.Camera.MoveForward(-0.1f);
                    }
                    if (Keyboard.GetState().IsKeyDown(Key.Left) || Keyboard.GetState(0).IsKeyDown(Key.A))
                    {
                        GameScene.gameInstance.player.Camera.RotateY(-0.01f);
                    }
                    if (Keyboard.GetState().IsKeyDown(Key.Right) || Keyboard.GetState(0).IsKeyDown(Key.D))
                    {
                        GameScene.gameInstance.player.Camera.RotateY(0.01f);
                    }
                    if (Keyboard.GetState().IsKeyDown(Key.M))
                    {
                        GameScene.gameInstance.sceneManager.ChangeScene(new MainMenuScene(GameScene.gameInstance.sceneManager));
                    }
                    break;
                case SceneTypes.SCENE_GAME_OVER:
                    if (Keyboard.GetState().IsKeyDown(Key.Escape))
                    {
                        GameOverScene.GameOverInstance.sceneManager.Exit();
                    }
                    if (Keyboard.GetState().IsKeyDown(Key.Space))
                    {
                        GameOverScene.GameOverInstance.sceneManager.ChangeScene(new MainMenuScene(GameOverScene.GameOverInstance.sceneManager));
                    }
                    break;
                case SceneTypes.SCENE_WIN:
                    if (Keyboard.GetState().IsKeyDown(Key.Escape))
                    {
                        WinScene.WinInstance.sceneManager.Exit();
                    }
                    if (Keyboard.GetState().IsKeyDown(Key.Space))
                    {
                        WinScene.WinInstance.sceneManager.ChangeScene(new MainMenuScene(WinScene.WinInstance.sceneManager));
                    }
                    break;
            }
           
        }
    }
}
