using CommonCharacter.Scripts;

namespace CommonUI.Scripts
{
    public interface IUIHpBar
    {
        void Initialize(ICharacterHealth characterHealth, bool isFlipped);
    }
}