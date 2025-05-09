using System;
using CommonCollision.Data;
using CommonCollision.Scripts;
using UnityEngine;

namespace Collision.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Hitbox : MonoBehaviour, IHitbox
    {
        public event Action OnHit = delegate { };
        public event Action OnBlock = delegate { };

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
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var hr = other.GetComponent<IHurtReceiver>();
            if (hr == null) return;
            
            var dir = (other.transform.position - Attacker.position).normalized;

            if (hr.IsBlocking(dir))
            {
                OnBlock();
            }
            else
            {
                OnHit();
                hr.ReceiveHit(Info.Damage, dir);
            }
            
            Destroy();
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}