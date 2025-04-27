using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace CommonCharacter.Scripts
{
    public class CharacterMovementController : MonoBehaviour
    {
        private Rigidbody2D rb;
        private CharacterSettings characterSettings;
        private bool isKnockedBack;
        private float knockbackTimer;
        private Vector2 knockbackVelocity;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            characterSettings = GetComponent<CharacterSettings>();
            
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0;
            rb.freezeRotation = true;
        }

        void Update()
        {
            if (isKnockedBack)
            {
                rb.MovePosition(rb.position + knockbackVelocity * Time.deltaTime);
                return;
            }
            
            float h = Input.GetAxis("Horizontal");
            float speed = characterSettings.stats.moveSpeed;
            var next = rb.position + Vector2.right * (h * speed * Time.deltaTime);
            rb.MovePosition(next);
        }

        public void ApplyKnockback(string attackName, Vector2 dir)
        {
            var ak = characterSettings.stats.attackKnockbacks.FirstOrDefault(x => x.attackName == attackName);
            float str = !string.IsNullOrEmpty(ak.attackName)
                ? ak.strength
                : characterSettings.stats.knockbackStrength;
            float dur = !string.IsNullOrEmpty(ak.attackName)
                ? ak.duration
                : characterSettings.stats.knockbackDuration;
            
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