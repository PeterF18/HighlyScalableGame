using CommonScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMainMenu
{
    public class MainMenuController : MonoBehaviour, ISceneSPI
    {
        public string GetSceneName()
        {
            return "SceneMainMenu";
        }
        
        public void OnPlayClicked()
        {
            SceneManager.LoadScene("SceneCharacterSelection");
        }
        
    }
}