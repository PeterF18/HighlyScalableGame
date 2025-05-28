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

        private void Awake()
        {
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInputController>();
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

        public void ReceiveHit(IAttackData data, Vector2 direction)
        {
            if (IsBlocking())
            {
                anim.SetTrigger("Block");
                _characterState.SetRecovery(data.RecoveryOnBlock);
            }
            else
            {
                anim.SetTrigger("Hit");
                _characterState.SetRecovery(data.RecoveryOnHit);
            }
        }
    }
}