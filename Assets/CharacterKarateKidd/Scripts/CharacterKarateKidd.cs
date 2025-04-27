using CommonCharacter.Scripts;
using Configs.Scripts;
using UnityEngine;

namespace CharacterKarateKidd.Scripts
{
    public class CharacterKarateKidd : MonoBehaviour, ICharacterSPI
    {
        public void Initialize(CharacterConfig config, Transform spawnPoint)
        {
            transform.position = spawnPoint.position;
        }
    }
}