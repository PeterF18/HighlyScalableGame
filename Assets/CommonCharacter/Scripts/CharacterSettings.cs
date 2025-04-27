using UnityEngine;

namespace CommonCharacter.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterSettings : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] CharacterStats stats;
        
        [Header("Attacks")]
        [SerializeField] AttackData[] attacks;
        
        public CharacterStats Stats => stats;
        public AttackData[] Attacks => attacks;
    }
}