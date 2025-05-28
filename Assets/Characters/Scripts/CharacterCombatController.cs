using System.Collections;
using System.Linq;
using CommonCharacter.Scripts;
using CommonCollision.Data;
using CommonCollision.Scripts;
using UnityEngine;
using Zenject;

namespace Characters.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class CharacterCombatController : MonoBehaviour, ICharacterCombat
    {
        [Inject] private IHitboxFactory _hitboxFactory;
        [Inject] private ICharacterBlock _blockController;
        [Inject] private ICharacterState _characterState;
        
        Animator animator;
        private bool inAttack;
        private IAttackData lastAttack;

        [SerializeField] private SpawnPair[] _spawnPairs;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public bool DoAttack(IAttackData data)
        {
            if (!_characterState.CanAct || inAttack) return false;
            
            // Am I root/neutral attack and no lastAttack yet?
            bool okRoot = data.IsComboRoot && lastAttack == null;
            
            // or am I a legal follow-up?
            bool okFollow = lastAttack != null && lastAttack.ComboFollowUps.Contains(data);

            if (!(okRoot || okFollow)) return false;
            
            StartCoroutine(PerformAttack(data));
            lastAttack = data;
            return true;
        }

        Transform GetSpawn(IAttackData data)
        {
            foreach (var p in _spawnPairs)
            {
                if (ReferenceEquals(p.attack, data))
                {
                    return p.spawnPoint;
                }
            }

            return transform;
        }

        IEnumerator PerformAttack(IAttackData data)
        {
            inAttack = true;

            // Startup frames
            yield return new WaitForSeconds(data.StartupFrames / 60f);
            
            // Trigger animation
            animator.SetTrigger(data.AttackName);
            
            // Spawn hitbox
            var info = new HitboxInfo()
            {
                Damage = data.Damage,
                Offset = data.HitboxOffset,
                Size = data.HitboxSize,
                LifeTimeFrames = data.StartupFrames
            };
            
            var spawn = GetSpawn(data).position;

            var hb = _hitboxFactory.CreateHitbox(
                info,
                spawn,
                transform);

            //This is to ensure that attacks can't hit the attacker themselves
            if (hb is MonoBehaviour mb)
            {
                var hbCollider = mb.GetComponent<Collider2D>();
                //So, here I ignore collition with the attack's owner
                foreach (var col in transform.root.GetComponentsInChildren<Collider2D>())
                {
                    Physics2D.IgnoreCollision(col, hbCollider);
                }
            }
            
            hb.OnTriggered += (other, hitInfo) =>
            {
                var dir = (other.transform.position - transform.position).normalized;

                if (other.TryGetComponent<ICharacterBlock>(out var block))
                {
                    block.ReceiveHit(data, dir);
                }
                else if (other.TryGetComponent<IHurtReceiver>(out var hr))
                {
                    if (hr.CanBeHit()) hr.TakeDamage(hitInfo.Damage, dir);
                }
            };
            
            // End
            inAttack = false;
            lastAttack = null;
        }
    }

    [System.Serializable]
    public class SpawnPair
    {
        public IAttackData attack;
        public Transform spawnPoint;
    }
}