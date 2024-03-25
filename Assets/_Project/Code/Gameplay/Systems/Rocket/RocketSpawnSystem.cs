using Infrastructure.ECS;
using UnityEngine;

namespace Gameplay
{
    public class RocketSpawnSystem : BaseSystem
    {
        private GameSettings _settings;

        public RocketSpawnSystem(GameSettings settings, GameInput gameInput)
        {
            _settings = settings;
        }

        protected override void OnPlayed()
        {
            CreateRocket();
        }

        private void CreateRocket()
        {
            ref var rocket = ref _world.NewEntity();

            rocket.SetComponent(new TransformComponent
            {
                position = Vector2.zero,
                rotation = Vector2.up
            });

            rocket.AddComponent<RigidbodyComponent>();
            rocket.AddComponent<MovementComponent>();
            rocket.SetComponent(new ColliderComponent()
            {
                radius = 0.45f
            });

            rocket.SetComponent(new RocketEngineComponent
            {
                power = _settings.rocket.enginePower,
            });
            rocket.SetComponent(new RocketRotateControlComponent()
            {
                speed = _settings.rocket.rotateSpeed,
            });

            rocket.SetComponent(new RocketWeaponComponent()
            {
                type = RocketWeaponType.BULLET
            });

            rocket.SetComponent(new SpriteRendererComponent
            {
                sprite = _settings.rocket.sprites[0],
                layer = 1,
            });

            rocket.SetComponent(new HealthComponent
            {
                value = 1,
                maxValue = 1
            });

            rocket.AddComponent<PortalTag>();
        }
    }
}