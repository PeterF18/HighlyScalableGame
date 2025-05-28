using System;
using CommonCollision.Data;
using CommonCollision.Scripts;
using UnityEngine;

namespace Collision.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Hitbox : MonoBehaviour, IHitbox
    {
        public event Action<Collider2D, HitboxInfo> OnTriggered = delegate { };
        

        internal HitboxInfo Info;
        internal Transform Attacker;
        internal BoxCollider2D Collider;

        void Awake()
        {
            Collider = GetComponent<BoxCollider2D>();
            Collider.isTrigger = true;
            Collider.enabled = false;
        }

        public void Configure(HitboxInfo info, Transform attacker)
        {
            Info = info;
            Attacker = attacker;
            
            Collider.size = info.Size;
            Collider.offset = info.Offset;
            Collider.enabled = true;

            if (info.LifeTimeFrames > 0)
            {
                float lifeTimeSeconds = info.LifeTimeFrames / 60f;
                UnityEngine.GameObject.Destroy(gameObject, lifeTimeSeconds);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggered(other, Info);
            UnityEngine.Object.Destroy(gameObject);
        }
        
        public void Destroy()
        {
            
        }
        
    }
}