using Gameplay;
using Gameplay.Render;
using Infrastructure.DI;
using Infrastructure.ECS;
using UnityEngine;

namespace Initializers.Gameplay
{
    public class GameplayInitializer
    {
        private const string CAMERA_TAG = "MainCamera";

        private const string CONFIG_PATH = "GameSettings";

        private Scope _scope;

        public GameplayInitializer(Scope scope, IEcsManager ecsManager)
        {
            _scope = new Scope(scope);

            var cameraObj = GameObject.FindGameObjectWithTag(CAMERA_TAG);

            if (cameraObj.TryGetComponent(out Camera camera))
            {
                scope.RegisterInstance(camera);
            }

            var settings = Resources.Load<GameSettingsScrobject>(CONFIG_PATH);
            scope.RegisterInstance(settings);

            ecsManager
               .AddSystem<RocketSpawnSystem>()
               .AddSystem<RocketInputSystem>();

            ecsManager
               .AddSystem<PhysicsSystem>()
               .AddSystem<MovementSystem>();

            ecsManager
               .AddSystem<RocketEngineSystem>()
               .AddSystem<RocketRotateControlSystem>()
               .AddSystem<RocketFrictionSystem>();

            ecsManager
               .AddSystem<SpriteRendererSystem>();

            ecsManager
               .AddSystem<ScreenPortalSystem>();
        }
    }
}