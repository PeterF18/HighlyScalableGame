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
        
        Animator animator;
        private bool inAttack;
        private AttackData lastAttack;

        [SerializeField] private SpawnPair[] _spawnPairs;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public bool DoAttack(AttackData data)
        {
            if (inAttack) return false;
            
            // Am I root/neutral attack and no lastAttack yet?
            bool okRoot = data.isComboRoot && lastAttack == null;
            
            // or am I a legal follow-up?
            bool okFollow = lastAttack != null && lastAttack.comboFollowUps.Contains(data);

            if (!(okRoot || okFollow)) return false;
            
            StartCoroutine(PerformAttack(data));
            lastAttack = data;
            return true;
        }

        Transform GetSpawn(AttackData data)
        {
            foreach (var p in _spawnPairs)
            {
                if (p.attack == data)
                {
                    return p.spawnPoint;
                }
            }

            return transform;
        }

        IEnumerator PerformAttack(AttackData data)
        {
            inAttack = true;

            // Startup frames
            yield return new WaitForSeconds(data.startupFrames / 60f);
            
            // Trigger animation
            animator.SetTrigger(data.attackName);
            
            // Spawn hitbox
            bool didHit = false;
            bool didBlock = false;

            var info = new HitboxInfo()
            {
                Damage = data.damage,
                Offset = data.hitboxOffset,
                Size = data.hitboxSize
            };
            
            var spawn = GetSpawn(data).position;

            var hb = _hitboxFactory.CreateHitbox(
                info,
                spawn,
                transform);
            
            hb.OnHit += () => didHit = true;
            hb.OnBlock += () => didBlock = true;
            
            // Recovery
            float recFrames;
            if (didHit) recFrames = data.recoveryOnHit;
            else if (didBlock) recFrames = data.recoveryOnBlock;
            else recFrames = 60;
            yield return new WaitForSeconds(recFrames / 60f);

            // End
            inAttack = false;
            lastAttack = null;
        }
    }

    [System.Serializable]
    public class SpawnPair
    {
        public AttackData attack;
        public Transform spawnPoint;
    }
}