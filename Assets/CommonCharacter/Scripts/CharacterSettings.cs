using UnityEngine;

namespace CommonCharacter.Scripts
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
    public class CharacterSettings : MonoBehaviour
    {
        public CharacterStats stats;
    }
}