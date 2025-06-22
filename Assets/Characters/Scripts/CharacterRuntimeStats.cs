using System;
using Characters.Data;
using CommonCharacter.Scripts;
using UnityEngine;

namespace Characters.Scripts
{
    public class CharacterRuntimeStats : MonoBehaviour, ICharacterHealth
    {
        public float maxHP { get; private set;  }
        public float currentHP { get; set; }
        
        private CharacterSettings characterSettings;
        private CharacterStats characterStats;

        private void Awake()
        {
            characterSettings = GetComponent<CharacterSettings>();
            characterStats = characterSettings.Stats;
            maxHP = characterStats.hp;
            currentHP = maxHP;
        }

        public CharacterRuntimeStats(float maxHP)
        {
            currentHP = maxHP;
            this.maxHP = maxHP;
        }
        
        
    }
}