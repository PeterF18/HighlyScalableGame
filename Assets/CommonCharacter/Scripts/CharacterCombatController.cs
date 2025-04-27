using System.Collections;
using System.Linq;
using UnityEngine;

namespace CommonCharacter.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class CharacterCombatController : MonoBehaviour
    {
        Animator animator;
        private bool inAttack;
        public AttackData[] allAttacks;
        private AttackData lastAttack;

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

        IEnumerator PerformAttack(AttackData data)
        {
            inAttack = true;

            // Startup frames
            yield return new WaitForSeconds(data.startupFrames / 60f);
            
            // Trigger animation
            animator.SetTrigger(data.attackName);
            
            // Then I need to add hitboxes at some point
            bool didConnect = false;
            
            // Recovery
            float recFrames = didConnect
                ? data.recoveryOnHit
                : data.recoveryOnBlock;
            yield return new WaitForSeconds(recFrames / 60f);

            // End
            inAttack = false;
            lastAttack = null;
        }
    }
}