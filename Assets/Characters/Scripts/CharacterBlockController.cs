using CommonCharacter.Scripts;
using UnityEngine;

namespace Characters.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class CharacterBlockController : MonoBehaviour, ICharacterBlock
    {
        private Animator anim;
        private PlayerInputController input;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            input = GetComponent<PlayerInputController>();
        }
        
        public bool isBlocking()
        {
            throw new System.NotImplementedException();
        }

        public void receiveBlock(AttackData data, Vector2 direction)
        {
            anim.SetTrigger("Block");
        }

        public void receiveHit(AttackData data, Vector2 direction)
        {
            anim.SetTrigger("Hurt");
        }
    }
}