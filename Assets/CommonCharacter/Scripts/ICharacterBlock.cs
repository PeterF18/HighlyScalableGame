using UnityEngine;

namespace CommonCharacter.Scripts
{
    public interface ICharacterBlock
    {
        bool isBlocking();
        void receiveBlock(AttackData data, Vector2 direction);
        void receiveHit(AttackData data, Vector2 direction);
    }
}