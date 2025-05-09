using System;
using System.Collections;
using System.Linq;
using CommonCharacter.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters.Scripts
{
    [RequireComponent(typeof(CharacterCombatController), typeof(CharacterSettings))]
    public class CpuAiController : MonoBehaviour
    {
        [Tooltip("Min/max delay between decisions")]
        public float minThink = 0.5f, maxThink = 1.5f;

        private bool aiActive;
        
        CharacterCombatController characterController;
        CharacterSettings characterSettings;

        void Awake()
        {
            characterController = GetComponent<CharacterCombatController>();
            characterSettings = GetComponent<CharacterSettings>();
        }

        private void OnEnable()
        {
            aiActive = true;
            StartCoroutine(AiLoop());
        }

        private void OnDisable()
        {
            aiActive = false;
        }
        
        IEnumerator AiLoop()
        {
            while (aiActive)
            {
                yield return new WaitForSeconds(Random.Range(minThink, maxThink));
                
                //I imagine we want it to chose a combo starter attack of some sort
                var attacks = characterSettings.Attacks.Where(a => a.isComboRoot).ToArray();
                if (attacks.Length == 0) yield break;
                
                var choice = attacks[Random.Range(0, attacks.Length)];
                characterController.DoAttack(choice);
            }
        }
    }
}