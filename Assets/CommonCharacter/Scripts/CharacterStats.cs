using UnityEngine;

namespace CommonCharacter.Scripts
{
    [CreateAssetMenu(menuName = "CommonCharacter/Stats")]
    public class CharacterStats : ScriptableObject
    {
        [Header("Movement")]
        public float moveSpeed = 15f;
        
        [Header("Knockback Defaults")]
        public float knockbackStrength = 5f;
        public float knockbackDuration = 0.2f;
    }
}