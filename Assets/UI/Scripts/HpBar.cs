using System;
using CommonCharacter.Scripts;
using CommonUI.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Scripts
{
    public class HpBar : MonoBehaviour, IUIHpBar
    {
        [SerializeField] private Slider slider;
        private ICharacterHealth characterHealth;
        
        public void Initialize(ICharacterHealth characterHealth, bool isFlipped)
        {
            this.characterHealth = characterHealth;
            slider.direction = isFlipped ? Slider.Direction.RightToLeft : Slider.Direction.LeftToRight;

            slider.maxValue = 1f;
            slider.value = 1f;
        }

        private void Update()
        {
            if (characterHealth != null)
            {
                slider.value = characterHealth.currentHP / characterHealth.maxHP;
            }
        }
    }
}