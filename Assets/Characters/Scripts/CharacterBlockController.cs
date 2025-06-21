using Characters.Data;
using CommonCharacter.Data;
using CommonCharacter.Scripts;
using UnityEngine;
using Zenject;

namespace Characters.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class CharacterBlockController : MonoBehaviour, ICharacterBlock
    {
        [Inject] private ICharacterState _characterState;
        
        private Animator anim;
        private PlayerInputController input;
        private CharacterRuntimeStats characterRuntimeStats;
        private CharacterSettings characterSettings;
        private CharacterStats characterStats;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInputController>();
            characterSettings = GetComponent<CharacterSettings>();
            characterStats = characterSettings.Stats;
            characterRuntimeStats = new CharacterRuntimeStats(characterStats.hp);
        }
        
        public bool IsBlocking()
        {
            switch (input.RelativeFacing)
            {
                case FacingDirection.Back:
                case FacingDirection.DownBack:
                case FacingDirection.Neutral:
                    return true;
                default:
                    return false;
            }
        }

        private void HandleDefeat()
        {
            if (characterSettings == null)
            {
                Debug.LogWarning("CharacterSettings not found. Cannot determine player ID.");
                return;
            }

            var loser = characterSettings.PlayerId;
            var winner = loser == 1 ? 2 : 1;
            Debug.Log($"Player {winner} wins!");
            
            Destroy(gameObject);
        }

        public void ReceiveHit(IAttackData data, Vector2 direction)
        {
            if (IsBlocking())
            {
                anim.SetTrigger("Block");
                _characterState.SetRecovery(data.RecoveryOnBlock);
            }
            else
            {
                //anim.SetTrigger("Hit");
                _characterState.SetRecovery(data.RecoveryOnHit);
                characterRuntimeStats.currentHP -= data.Damage;
                Debug.Log($"{gameObject.name} took {data.Damage} damage. Remaining HP: {characterRuntimeStats.currentHP}");

                if (characterRuntimeStats.currentHP <= 0)
                {
                    HandleDefeat();
                }
            }
        }
    }
}