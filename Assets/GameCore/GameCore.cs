using CommonScene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore
{
    public class GameCore : MonoBehaviour
    {
        [SerializeField]
        private BaseSceneSPI sceneMainMenu; 


        private void Start()
        {
            string sceneName = sceneMainMenu.GetSceneName();
            SceneManager.LoadScene(sceneName);
        }
        
    }

}