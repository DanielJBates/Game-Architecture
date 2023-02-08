using System.Collections.Generic;
using EngineLibrary.Components;
using EngineLibrary.Managers;
using OpenGL_Game.Game.Scenes;

namespace OpenGL_Game.Game.Managers
{
    class EscapeGameCollisionManager : CollisionManager
    {
        public override void ProcessCollision()
        {
            foreach (Collision coll in CollisionManifold)
            {
                if (coll.entity.Name == "Drone")
                {
                    GameScene.gameInstance.player.Camera.InitialState();

                    IComponent transformComponent = coll.entity.Components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                    });
                    ComponentTransform transform = (ComponentTransform)transformComponent;
                    transform.InitialState();

                    GameScene.gameInstance.player.Lives -= 1;
                }
                if (coll.entity.Name == "Keycard1" || coll.entity.Name == "Keycard2" || coll.entity.Name == "Keycard3")
                {
                    List<IComponent> components = coll.entity.Components;

                    IComponent audioComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                    });
                    ((ComponentAudio)audioComponent).Play();

                    GameScene.gameInstance.GetEntityManager.RemoveEntity(coll.entity);
                    GameScene.gameInstance.player.Keycards += 1;
                }
                if (coll.entity.Name == "Portal ON")
                {
                    List<IComponent> components = coll.entity.Components;

                    IComponent audioComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                    });
                    ((ComponentAudio)audioComponent).Stop();

                    GameScene.gameInstance.sceneManager.ChangeScene(new WinScene(GameScene.gameInstance.sceneManager));
                }
            }
        }
    }
}
