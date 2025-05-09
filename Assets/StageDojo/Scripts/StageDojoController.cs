using CommonStage.Scripts;
using Configs.Scripts;
using UnityEngine;
using Zenject;

namespace DojoStage.Scripts
{
    public class StageDojoController : MonoBehaviour, IStageSPI
    {
        [Inject] DiContainer _container;
        [SerializeField] private Transform player1SpawnPoint;
        [SerializeField] private Transform player2SpawnPoint;
        [SerializeField] private CharacterConfig characterConfig;
        
        public void InitializeStage(CharacterConfig config)
        {
            Debug.Log($"[StageDojo] InitializeStage called – options.Count = {config.Options.Length}");
            if (config.Options.Length == 0)
            {
                Debug.LogError("[StageDojo] You forgot to fill the CharacterConfig.options list in the inspector!");
                return;
            }

            Debug.Log($"[StageDojo] Spawning P1 at {player1SpawnPoint.position}, P2 at {player2SpawnPoint.position}");

            _container.InstantiatePrefab(
                config.SelectedPlayer1,
                player1SpawnPoint.position,
                player1SpawnPoint.rotation,
                null);

            _container.InstantiatePrefab(
                config.SelectedPlayer2,
                player2SpawnPoint.position,
                player2SpawnPoint.rotation,
                null);
        }
    }
}