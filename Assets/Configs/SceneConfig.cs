using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Configs/SceneConfig")]
    public class SceneConfig : ScriptableObject
    {
        public string mainMenu = "SceneMainMenu";
        public string characterSelection = "SceneCharacterSelection";
    }
}