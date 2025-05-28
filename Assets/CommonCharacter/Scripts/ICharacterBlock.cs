using UnityEngine;

namespace CommonCharacter.Scripts
{
    public interface ICharacterBlock
    {
        bool IsBlocking();
        void ReceiveHit(IAttackData data, Vector2 direction);
    }
}