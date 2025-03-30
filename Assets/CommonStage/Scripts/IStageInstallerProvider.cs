using System.Collections.Generic;
using UnityEngine;

namespace CommonStage.Scripts
{
    public interface IStageInstallerProvider
    {
        IEnumerable<GameObject> GetStageInstallerPrefabs();
    }
}