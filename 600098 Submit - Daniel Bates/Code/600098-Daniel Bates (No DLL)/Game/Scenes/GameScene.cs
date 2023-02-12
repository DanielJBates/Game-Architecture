using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenGL_Game.Components;
using OpenGL_Game.Engine.Components;
using OpenGL_Game.Systems;
using OpenGL_Game.Managers;
using OpenGL_Game.Engine.Managers;
using OpenGL_Game.Game.Managers;
using OpenGL_Game.Engine.Objects;
using OpenGL_Game.Objects;
using OpenGL_Game.Game.Objects;
using System.Drawing;
using System;
using OpenTK.Audio.OpenAL;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace OpenGL_Game.Scenes
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>

    class GameScene : Scene
    {
        EntityManager entityManager;
        SystemManager systemManager;
        CollisionManager collisionManager;

        public MazeEscapePlayer player;

        public static GameScene gameInstance;

        bool PortalState = false;
        public static float dt = 0;

        public GameScene(SceneManager sceneManager) : base(sceneManager)
        {
            gameInstance = this;
            entityManager = new EntityManager();
            systemManager = new SystemManager();
            collisionManager = new EscapeGameCollisionManager();
            // Set the title of the window
            sceneManager.Title = "Maze Escape - Game";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;

            // Enable Depth Testing
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            CreateEntities();
            CreateSystems();

            // TODO: Add your initialization logic here

        }

        private void CreateEntities()
        {
            player = new MazeEscapePlayer(new Camera(new Vector3(-8.0f, 1.25f, 7), new Vector3(-8.0f, 1.25f, 0), (float)(sceneManager.Width) / (float)(sceneManager.Height), 0.1f, 100f));
            player.AddComponent(new ComponentTransform(player.Camera.cameraPosition, Matrix4.CreateRotationX(MathHelper.DegreesToRadians(0.0f)), new Vector3(1.0f)));
            player.AddComponent(new ComponentCollisionSphere(1.0f));
            entityManager.AddEntity(player);

            Entity newEntity; 

            newEntity = new Entity("Skybox");
            newEntity.AddComponent(new ComponentTransform(player.Camera.cameraPosition, Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)), new Vector3(25.0f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Skybox/Skybox.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Maze");
            newEntity.AddComponent(new ComponentTransform(new Vector3(0.0f, 0.0f, 0.0f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)), new Vector3(1.0f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Maze/Maze.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Keycard1");
            newEntity.AddComponent(new ComponentTransform(new Vector3(-8.0f, 0.5f, -8.0f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)), new Vector3(0.5f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Keycard/Keycard.obj"));
            newEntity.AddComponent(new ComponentCollisionSphere(0.5f));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentAudio("Game/Audio/blip(PickUp).wav", false));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Keycard2");
            newEntity.AddComponent(new ComponentTransform(new Vector3(8.0f, 0.5f, -8.0f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)), new Vector3(0.5f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Keycard/Keycard.obj"));
            newEntity.AddComponent(new ComponentCollisionSphere(0.5f));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentAudio("Game/Audio/blip(PickUp).wav", false));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Keycard3");
            newEntity.AddComponent(new ComponentTransform(new Vector3(8.0f, 0.5f, 8.0f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)), new Vector3(0.5f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Keycard/Keycard.obj"));
            newEntity.AddComponent(new ComponentCollisionSphere(0.5f));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentAudio("Game/Audio/blip(PickUp).wav", false));
            entityManager.AddEntity(newEntity);            
            
            newEntity = new Entity("Portal OFF");
            newEntity.AddComponent(new ComponentTransform(new Vector3(-7.5f, 0.0f, 10.0f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(180.0f)), new Vector3(0.75f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Portal/Portal OFF/Portal OFF.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentAudio("Game/Audio/buzz(PortalOFF).wav", true));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Portal ON");
            newEntity.AddComponent(new ComponentTransform(new Vector3(-7.5f, -5.0f, 10.0f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(180.0f)), new Vector3(0.75f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Portal/Portal ON/Portal ON.obj")); 
            newEntity.AddComponent(new ComponentCollisionSphere(0.75f));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentAudio("Game/Audio/laser_x(PortalON).wav", true));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("SpikePillar");
            newEntity.AddComponent(new ComponentTransform(new Vector3(-8.0f, -0.25f, -5.5f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)), new Vector3(1.0f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/SpikePillar/SpikePillar.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("SpikeBall");
            newEntity.AddComponent(new ComponentTransform(new Vector3(5.5f, 0.5f, -5.5f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)), new Vector3(0.5f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/SpikeBall/SpikeBall.obj"));
            newEntity.AddComponent(new ComponentShaderDefault());
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Drone");
            newEntity.AddComponent(new ComponentTransform(new Vector3(0.0f, 1.0f, 0.0f), Matrix4.CreateRotationY(MathHelper.DegreesToRadians(0.0f)), new Vector3(0.35f)));
            newEntity.AddComponent(new ComponentGeometry("Game/Geometry/Drone/Drone.obj"));
            newEntity.AddComponent(new ComponentCollisionSphere(1.0f));
            newEntity.AddComponent(new ComponentShaderDefault());
            newEntity.AddComponent(new ComponentAudio("Game/Audio/news_x(Drone).wav", true));
            entityManager.AddEntity(newEntity);
        }

        private void CreateSystems()
        {
            ISystem newSystem;

            newSystem = new SystemRender();
            systemManager.AddSystem(newSystem);

            newSystem = new SystemPhysics();
            systemManager.AddSystem(newSystem);

            newSystem = new SystemAudio();
            systemManager.AddSystem(newSystem);

            newSystem = new SystemCollisionCameraSphere(collisionManager, player.Camera);
            systemManager.AddSystem(newSystem);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="e">Provides a snapshot of timing values.</param> 

        public void UpdateSkybox()
        {
            Entity tempEntity = entityManager.FindEntity("Skybox");
            List<IComponent> components = tempEntity.Components;

            IComponent transformComponent = components.Find(delegate (IComponent component)
            {
                return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
            });
            ((ComponentTransform)transformComponent).Position = player.Camera.cameraPosition;
        }

        public override void Update(FrameEventArgs e)
        {
            if (player.Lives == 0)
            {
                Entity tempEntity = entityManager.FindEntity("Drone");
                List<IComponent> components = tempEntity.Components;

                IComponent audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });

                if (((ComponentAudio)audioComponent).PlayState == true)
                {
                    ((ComponentAudio)audioComponent).Stop();
                }

                if (PortalState == false)
                {
                    tempEntity = entityManager.FindEntity("Portal OFF");
                    components = tempEntity.Components;

                    audioComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                    });

                    if (((ComponentAudio)audioComponent).PlayState == true)
                    {
                        ((ComponentAudio)audioComponent).Stop();
                    }
                }
                else if (PortalState == true)
                {
                    tempEntity = entityManager.FindEntity("Portal ON");
                    components = tempEntity.Components;

                    audioComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                    });

                    if (((ComponentAudio)audioComponent).PlayState == true)
                    {
                        ((ComponentAudio)audioComponent).Stop();
                    }
                }

                sceneManager.ChangeScene(SceneTypes.SCENE_GAME_OVER);
                return;
            }
            if (player.Keycards != 3)
            {
                Entity tempEntity = entityManager.FindEntity("Portal OFF");
                List<IComponent> components = tempEntity.Components;

                IComponent audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });

                if (((ComponentAudio)audioComponent).PlayState == false)
                {
                    ((ComponentAudio)audioComponent).Play();
                }
            }
            if (player.Keycards == 3 && PortalState == false)
            {
                PortalState = true;

                Entity tempEntity = entityManager.FindEntity("Portal OFF");
                List<IComponent> components = tempEntity.Components;

                IComponent audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });
                ((ComponentAudio)audioComponent).Stop();

                entityManager.RemoveEntity(entityManager.FindEntity("Portal OFF"));

                tempEntity = entityManager.FindEntity("Portal ON");
                components = tempEntity.Components;

                IComponent transformComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                });
                ((ComponentTransform)transformComponent).Position += new Vector3(0.0f,5.0f,0.0f);

                audioComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_AUDIO;
                });
                ((ComponentAudio)audioComponent).Play();
            }

            dt = (float)e.Time;
            //System.Console.WriteLine("fps=" + (int)(1.0/dt));

            if (GamePad.GetState(1).Buttons.Back == ButtonState.Pressed)
                sceneManager.Exit();

            // TODO: Add your update logic here
            inputManager.ProcessInputs(SceneTypes.SCENE_GAME);

            UpdateSkybox();

            AL.Listener(ALListener3f.Position, ref player.Camera.cameraPosition);
            AL.Listener(ALListenerfv.Orientation, ref player.Camera.cameraDirection, ref player.Camera.cameraUp);

            collisionManager.ProcessCollision();
            collisionManager.ClearManifold();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="e">Provides a snapshot of timing values.</param>
        public override void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Action ALL systems
            systemManager.ActionSystems(entityManager);

            // Render score
            float width = sceneManager.Width, height = sceneManager.Height, fontSize = Math.Min(width, height) / 10f;
            GUI.clearColour = Color.Transparent;
            GUI.Label(new Rectangle(0, 0, (int)width, (int)(fontSize * 2f)), ("Keycards: "+ player.Keycards), 18, StringAlignment.Near, Color.White);
            GUI.Label(new Rectangle((int)width - (int)(fontSize + 10), 0, (int)width, (int)(fontSize * 2f)), ("Lives: " + player.Lives), 18, StringAlignment.Near, Color.White);
            GUI.Render();
        }

        /// <summary>
        /// This is called when the game exits.
        /// </summary>
        public override void Close()
        {   
            ResourceManager.RemoveAllAssets();
        }

        public EntityManager GetEntityManager
        {
            get { return entityManager; }
        }
    }
}
