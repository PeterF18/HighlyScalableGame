using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Configs/SceneConfig")]
    public class SceneConfig : ScriptableObject
    {
        public string mainMenu = "SceneMainMenu";
        public string characterSelection = "SceneCharacterSelection";
        public string stageSelection = "SceneStageSelection";
        public string stageDojo = "StageDojo";
    }
}