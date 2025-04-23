using CommonScene.Scripts;
using Configs.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneCharacterSelection.Scripts
{
    public class CharacterSelectionController : MonoBehaviour, ISceneSPI
    {
        [SerializeField]
        private SceneConfig sceneConfig;
        [SerializeField]
        private CharacterConfig characterConfig;
        
        public string GetSceneName()
        {
            return "SceneCharacterSelection";
        }
        
        // Called when p1 picks
        public void OnPlayer1Chosen(int index)
        {
            characterConfig.SelectedIndex1 = index;
        }
        
        // P2 and we definitely need to update for CPU choice
        public void OnPlayer2Chosen(int index)
        {
            characterConfig.SelectedIndex2 = index;
        }
        
        public void OnNextClicked()
        {
            SceneManager.LoadScene(sceneConfig.stageSelection);
        }
        
    }
}