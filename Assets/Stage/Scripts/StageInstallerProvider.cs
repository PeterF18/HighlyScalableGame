using System.Collections.Generic;
using CommonStage.Scripts;
using UnityEngine;

namespace Stage.Scripts
{
    [CreateAssetMenu(menuName = "Game/StageInstallerProvider")]
    public class StageInstallerProvider : ScriptableObject, IStageInstallerProvider
    {
        [SerializeField] private List<GameObject> installerPrefabs;
            
        public IEnumerable<GameObject> GetStageInstallerPrefabs(){ 
            return installerPrefabs;
        }
    }
}