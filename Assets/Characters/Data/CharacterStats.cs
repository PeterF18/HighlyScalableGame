using UnityEngine;

namespace Characters.Data
{
    [CreateAssetMenu(menuName = "Character/Stats")]
    public class CharacterStats : ScriptableObject
    {
        [Header("Health Points")] 
        public float hp = 150;
        
        [Header("Movement")]
        public float moveSpeed = 15f;
        
        [Header("Knockback Defaults")]
        public float knockbackStrength = 5f;
        public float knockbackDuration = 0.2f;
    }
}