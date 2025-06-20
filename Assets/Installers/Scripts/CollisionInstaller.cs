﻿using CommonCollision.Scripts;
using UnityEngine;
using Zenject;

namespace Collision.Scripts
{
    public class CollisionInstaller : MonoInstaller
    {
        [SerializeField] GameObject HitboxPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<IHitboxFactory>()
                .To<HitboxFactory>()
                .AsSingle();

            Container.Bind<GameObject>()
                .WithId("HitboxPrefab")
                .FromInstance(HitboxPrefab);
        }
    }
}