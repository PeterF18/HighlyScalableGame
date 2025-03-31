using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageSelectionScene
{
    public class StageSelectionController
    {
        public void OnNextClicked()
        {
            SceneManager.LoadScene("StageScene");
        }
    }
}