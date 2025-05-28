using System.Collections;
using System.Linq;
using Characters.Data;
using CommonCharacter.Scripts;
using UnityEngine;
using Zenject;

namespace Characters.Scripts
{
    [RequireComponent(typeof(CharacterSettings), typeof(Rigidbody2D))]
    public class CharacterMovementController : MonoBehaviour, ICharacterMovement
    {
        [Inject] private ICharacterState _characterState;
        
        private Rigidbody2D rb;
        private CharacterSettings characterSettings;
        private bool isKnockedBack;
        private float knockbackTimer;
        private Vector2 knockbackVelocity;
        private float movementDirection;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            characterSettings = GetComponent<CharacterSettings>();
            
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0;
            rb.freezeRotation = true;
        }

        void FixedUpdate()
        {
            if (isKnockedBack)
            {
                rb.MovePosition(rb.position + knockbackVelocity * Time.deltaTime);
                return;
            }
            
            if (!_characterState.CanAct)
            {
                return;
            }
            
            var next = rb.position + Vector2.right * (movementDirection * characterSettings.Stats.moveSpeed * Time.deltaTime);
            rb.MovePosition(next);
        }

        public void SetMovementDirection(float x)
        {
            movementDirection = x;
        }

        public void ApplyKnockback(string attackName, Vector2 dir)
        {
            var ad = characterSettings.Attacks.FirstOrDefault(x => x.AttackName == attackName);
            float str = !string.IsNullOrEmpty(ad.AttackName)
                ? ad.Damage
                : characterSettings.Stats.knockbackStrength;
            float dur = !string.IsNullOrEmpty(ad.AttackName)
                ? ad.RecoveryOnBlock
                : characterSettings.Stats.knockbackDuration;
            
            knockbackVelocity = dir.normalized * str;
            knockbackTimer = dur;
            StartCoroutine(KnockbackCR());
        }

        IEnumerator KnockbackCR()
        {
            isKnockedBack = true;
            yield return new WaitForSeconds(knockbackTimer);
            isKnockedBack = false;
        }
    }
}