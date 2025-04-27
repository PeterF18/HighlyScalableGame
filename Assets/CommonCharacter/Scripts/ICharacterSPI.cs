using Configs.Scripts;
using UnityEngine;

namespace CommonCharacter.Scripts
{
    public interface ICharacterSPI
    {
        void Initialize(CharacterConfig config, Transform spawnPoint);
    }
}