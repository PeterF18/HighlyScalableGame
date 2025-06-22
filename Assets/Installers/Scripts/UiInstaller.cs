using CommonUI.Scripts;
using UI.Scripts;
using Zenject;

namespace Installers.Scripts
{
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIHpBar>()
                .To<HpBar>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}