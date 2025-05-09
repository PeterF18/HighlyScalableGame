using CommonCharacter.Scripts;
using UnityEngine;
using Zenject;

namespace Characters.Scripts
{
    public class CharactersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICharacterMovement>()
                .To<CharacterMovementController>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<ICharacterCombat>()
                .To<CharacterCombatController>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<ICharacterBlock>()
                .To<CharacterBlockController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
        
    }
}