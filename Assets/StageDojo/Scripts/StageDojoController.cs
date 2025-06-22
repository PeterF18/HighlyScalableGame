using CommonCharacter.Scripts;
using CommonStage.Scripts;
using CommonUI.Scripts;
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
        
        //For Demo
        [SerializeField] private GameObject hpBarPrefab;
        [SerializeField] private Transform hpBar1Anchor;
        [SerializeField] private Transform hpBar2Anchor;
        
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
            
            //Assign IDs for DEMO
            p1GO.GetComponent<ICharacterInitializer>()?.InitializeCharacter(1);
            p2GO.GetComponent<ICharacterInitializer>()?.InitializeCharacter(2);

            var p1Health = p1GO.GetComponent<ICharacterHealth>();
            var p2Health = p2GO.GetComponent<ICharacterHealth>();

            var anchor1 = hpBar1Anchor as RectTransform;
            var anchor2 = hpBar2Anchor as RectTransform;
            SpawnHpBar(anchor1, p1Health, false);
            SpawnHpBar(anchor2, p2Health, true);
        }
        
        void SpawnHpBar(RectTransform anchorRT, ICharacterHealth health, bool isFlipped)
        {
            // 1) Instantiate your bar (no parent yet)
            var barGO = _container.InstantiatePrefab(hpBarPrefab) as GameObject;
            var barRT = barGO.GetComponent<RectTransform>();

            // 2) Parent under the Canvas (ensures we’re in UI space)
            var canvasRT = anchorRT.GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            barRT.SetParent(canvasRT, worldPositionStays: false);
            Debug.Log($"Bar parent: {barRT.parent.name}");
            Debug.Log($"Bar anchors: min={barRT.anchorMin} max={barRT.anchorMax} pos={barRT.anchoredPosition}");


            // 3) Copy the anchor’s RectTransform settings exactly
            barRT.anchorMin        = anchorRT.anchorMin;
            barRT.anchorMax        = anchorRT.anchorMax;
            barRT.pivot            = anchorRT.pivot;
            barRT.anchoredPosition = anchorRT.anchoredPosition;
            barRT.localScale       = Vector3.one;
            barRT.localRotation    = Quaternion.identity;

            // 4) Initialize the slider
            barGO.GetComponent<IUIHpBar>().Initialize(health, isFlipped);
        }
    }
}