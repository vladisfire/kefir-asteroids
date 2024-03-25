﻿using System.Collections.Generic;
using Gameplay.Utility;
using Infrastructure.ECS;
using UnityEngine;

namespace Gameplay.Render
{
    public class ParticleRendererSystem : BaseSystem
    {
        private Mask _mask;

        private List<ParticleSystem> _renderers = new(32);

        private ParticleSystemPool _pool;

        public ParticleRendererSystem(ParticleSystemPool pool)
        {
            _pool = pool;
        }

        protected override void OnInitialize()
        {
            Mask<TransformComponent, ParticleComponent>().Build(out _mask);
        }

        protected override void OnUpdate(float deltaTime)
        {
            // foreach (var render in _renderers)
            // {
            //     if (render.isPlaying) continue;
            //     
            //     _pool.Release(render);
            // }
            //
            // _renderers.Clear();
            //
            // foreach (var entity in _mask)
            // {
            //     ref var render = ref entity.GetComponent<SpriteRendererComponent>();
            //     ref var transform = ref entity.GetComponent<TransformComponent>();
            //
            //     var view = _pool.Get();
            //     view.sprite = render.sprite;
            //
            //     if (render.color != Color.clear)
            //         view.color = render.color;
            //
            //     view.sortingOrder = render.layer;
            //
            //     view.transform.position = transform.position;
            //     view.transform.rotation = transform.rotation.ToQuaternion();
            //
            //     _renderers.Add(view);
            // }
        }
    }
}