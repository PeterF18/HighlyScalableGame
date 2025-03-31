using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenuScene
{
    public class MainMenuController : MonoBehaviour
    {
        public void OnPlayClicked()
        {
            SceneManager.LoadScene("SceneCharacterSelection");
        }

    }
}