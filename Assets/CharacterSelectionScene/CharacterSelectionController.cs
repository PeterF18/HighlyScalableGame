using UnityEngine;
using UnityEngine.SceneManagement;

namespace CharacterSelectionScene
{
    public class CharacterSelectionController
    {
        public void OnNextClicked()
        {
            SceneManager.LoadScene("StageSelectionScene");
        }
    }
}