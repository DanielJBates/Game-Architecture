using OpenTK;

namespace EngineLibrary.Scenes
{
    public interface IScene
    {
        void Render(FrameEventArgs e);
        void Update(FrameEventArgs e);
        void Close();
    }
    public enum SceneTypes
    {
        SCENE_NONE,
        SCENE_DEFAULT,
        SCENE_MAIN_MENU,
        SCENE_GAME,
        SCENE_GAME_OVER,
        SCENE_WIN
    }
}
