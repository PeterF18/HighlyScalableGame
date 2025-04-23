using UnityEngine;
using CommonStage.Scripts;
using Configs.Scripts;

namespace StageDojoOutside.Scripts
{
    public class StageDojoOutsideController : MonoBehaviour, IStageSPI
    {
        [SerializeField] private Transform player1SpawnPoint;
        [SerializeField] private Transform player2SpawnPoint;
        [SerializeField] private CharacterConfig characterConfig;
        
        public void InitializeStage(CharacterConfig config)
        {
            var p1 = Instantiate(config.SelectedPlayer1, player1SpawnPoint.position, player1SpawnPoint.rotation);
            var p2 = Instantiate(config.SelectedPlayer2, player2SpawnPoint.position, player2SpawnPoint.rotation);
        }
    }
}   