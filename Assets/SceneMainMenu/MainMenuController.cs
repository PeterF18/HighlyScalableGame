using CommonScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneMainMenu
{
    public class MainMenuController : BaseSceneSPI
    {
        public override string GetSceneName()
        {
            return "SceneMainMenu";
        }
        
        public void OnPlayClicked()
        {
            SceneManager.LoadScene("SceneCharacterSelection");
        }
        
    }
}