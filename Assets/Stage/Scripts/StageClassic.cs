using CommonStage.Scripts;
using UnityEngine;

namespace Stage.Scripts
{
    public class StageClassic : MonoBehaviour, StageSPI
    {
        public void CreateStage()
        {
            Debug.Log("[StageClassic] Stage logic booted.");
        }
    }
}