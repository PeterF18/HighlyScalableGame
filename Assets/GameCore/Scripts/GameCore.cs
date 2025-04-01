using Common.Scripts;
using CommonStage.Scripts;
using UnityEngine;
using Zenject;

namespace GameCore.Scripts
{
    public class GameCore : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("[GameCore] Discovering implementations...");
            SPILoader.LoadAndBindAll<StageSPI>(Container, "Stages");
        }
    }

}