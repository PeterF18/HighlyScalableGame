using System;
using System.Collections;
using System.Linq;
using CommonCharacter.Scripts;
using UnityEngine;

namespace Characters.Scripts
{
    [RequireComponent(typeof(CharacterSettings), typeof(Rigidbody2D))]
    public class CharacterMovementController : MonoBehaviour, ICharacterMovement
    {
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
            
            var next = rb.position + Vector2.right * (movementDirection * characterSettings.Stats.moveSpeed * Time.deltaTime);
            rb.MovePosition(next);
        }

        public void SetMovementDirection(float x)
        {
            movementDirection = x;
        }

        public void ApplyKnockback(string attackName, Vector2 dir)
        {
            var ad = characterSettings.Attacks.FirstOrDefault(x => x.attackName == attackName);
            float str = !string.IsNullOrEmpty(ad.attackName)
                ? ad.damage
                : characterSettings.Stats.knockbackStrength;
            float dur = !string.IsNullOrEmpty(ad.attackName)
                ? ad.recoveryOnBlock
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