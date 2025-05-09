using CommonCollision.Data;
using CommonCollision.Scripts;
using UnityEngine;
using Zenject;

namespace Collision.Scripts
{
    public class HitboxFactory : IHitboxFactory
    {
        readonly GameObject _hitboxPrefab;
        readonly DiContainer _container;

        [Inject]
        public HitboxFactory([Inject(Id = "HitboxPrefab")] GameObject hitboxPrefab, DiContainer container)
        {
            _hitboxPrefab = hitboxPrefab;
            _container = container;
        }

        public IHitbox CreateHitbox(HitboxInfo info, Vector2 worldPos, Transform attacker)
        {
            var go = _container.InstantiatePrefab(
                _hitboxPrefab,
                worldPos,
                Quaternion.identity,
                null
                );
            
            var hb = go.GetComponent<Hitbox>();
            hb.Configure(info, attacker);
            return hb;
        }
    }
}