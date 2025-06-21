using CommonCharacter.Scripts;
using UnityEngine;

namespace Characters.Data
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterSettings : MonoBehaviour, ICharacterInitializer
    {
        [Header("Stats")]
        [SerializeField] CharacterStats stats;
        
        [Header("Attacks")]
        [SerializeField] AttackData[] attacks;
        
        public CharacterStats Stats => stats;
        public AttackData[] Attacks => attacks;
        
        
        //For DEMO
        public int PlayerId { get; private set; }
        
        public void InitializeCharacter(int playerId)
        {
            PlayerId = playerId;
        }
    }
}