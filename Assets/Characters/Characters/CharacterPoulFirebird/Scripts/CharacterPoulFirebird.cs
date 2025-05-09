using CommonCharacter.Scripts;
using Configs.Scripts;
using UnityEngine;

namespace Characters.CharacterPoulFirebird.Scripts
{
    public class CharacterPoulFirebird : MonoBehaviour, ICharacterSPI
    {
        public void Initialize(CharacterConfig config, Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
        }
    }
}