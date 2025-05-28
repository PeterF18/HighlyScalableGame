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
            var p1GO = _container.InstantiatePrefab(
                config.SelectedPlayer1,
                player1SpawnPoint.position,
                Quaternion.identity,
                null);
            
            var p2GO = _container.InstantiatePrefab(
                config.SelectedPlayer2,
                player2SpawnPoint.position,
                Quaternion.identity,
                null);
            
            //Flipping p2
            var p2Transform = p2GO.transform;
            var localScale = p2Transform.localScale;
            localScale.x *= -1f;
            p2Transform.localScale = localScale;
        }
    }
}