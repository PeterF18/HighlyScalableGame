namespace CommonCharacter.Scripts
{
    public interface ICharacterState
    {
        bool CanAct { get; }
        void SetRecovery(int frames);
    }
}