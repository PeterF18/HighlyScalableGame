using UnityEngine;

namespace CommonCharacter.Scripts
{
    [CreateAssetMenu(menuName = "Character/Stats")]
    public class CharacterStats : ScriptableObject
    {
        [Header("Movement")]
        public float moveSpeed = 5f;
        
        [Header("Knockback (deafults)")]
        public float knockbackStrength = 5f;
        public float knockbackDuration = 0.2f;

        [Header("Per-Attack Overrides")] 
        public AttackKnockback[] attackKnockbacks;
        
        //HEALTH AT SOME POINT

    }

    [System.Serializable]
    public struct AttackKnockback
    {
        public string attackName;
        public float strength;
        public float duration;
    }
}