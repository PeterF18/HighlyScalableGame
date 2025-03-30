using CommonStage.Scripts;
using UnityEngine;

namespace Stage.Scripts
{
    public class Stage : MonoBehaviour, StageSPI
    {
        public void LoadStage(string stageName)
        {
            Debug.Log($"[Stage] Loading stage: {stageName}");
            // TODO: Implement the stage logic
        }
        
    }
}