using Characters.Data;
using Characters.Scripts;
using CommonCharacter.Scripts;
using UnityEngine;
using Zenject;

namespace Installers.Scripts
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
            
            Container.Bind<ICharacterState>()
                .To<CharacterStateController>()
                .FromComponentInHierarchy()
                .AsSingle();
            
            Container.Bind<ICharacterInitializer>()
                .To<CharacterSettings>()
                .FromComponentInHierarchy()
                .AsSingle();
            
        }
        
    }
}