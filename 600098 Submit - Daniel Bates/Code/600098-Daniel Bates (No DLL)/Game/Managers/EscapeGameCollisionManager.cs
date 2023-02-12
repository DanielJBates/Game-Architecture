using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenGL_Game.Scenes;
using OpenGL_Game.Components;
using OpenGL_Game.Engine.Components;
using OpenGL_Game.Systems;
using OpenGL_Game.Managers;
using OpenGL_Game.Objects;
using OpenTK;

namespace OpenGL_Game.Managers
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

                    GameScene.gameInstance.sceneManager.ChangeScene(SceneTypes.SCENE_WIN);
                }
            }
        }
    }
}
