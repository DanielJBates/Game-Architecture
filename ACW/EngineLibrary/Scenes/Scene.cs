using OpenTK;
using EngineLibrary.Managers;

namespace EngineLibrary.Scenes
{
    public abstract class Scene : IScene
    {
        public SceneManager sceneManager; //was protected
        public static InputManager inputManager;

        public SceneTypes sceneType;

        public static float dt = 0;

        public Scene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
            sceneType = SceneTypes.SCENE_NONE;
        }

        public abstract void Render(FrameEventArgs e);

        public abstract void Update(FrameEventArgs e);

        public abstract void Close();
    }
}
