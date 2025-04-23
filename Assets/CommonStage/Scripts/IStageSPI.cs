using Configs.Scripts;

namespace CommonStage.Scripts
{
    public interface IStageSPI
    {
        void InitializeStage(CharacterConfig config);
    }
}