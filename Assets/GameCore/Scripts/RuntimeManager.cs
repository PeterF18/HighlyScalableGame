using CommonStage.Scripts;
using UnityEngine;
using Zenject;

namespace GameCore.Scripts
{
    public class RuntimeManager  : MonoBehaviour
    {
        [Inject] private StageSPI _stage;

        private void Start()
        {
            Debug.Log("[RuntimeManager] Starting modules...");
            _stage.CreateStage();
        }
        
    }
}