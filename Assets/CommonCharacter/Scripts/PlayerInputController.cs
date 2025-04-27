using System;
using System.Linq;
using UnityEngine;

namespace CommonCharacter.Scripts
{
    [RequireComponent(typeof(CharacterCombatController), typeof(CharacterSettings))]
    public class PlayerInputController : MonoBehaviour
    {
        public enum Player { P1, P2 }
        
        [SerializeField]
        Player player = Player.P1;
        
        CharacterCombatController characterController;
        CharacterSettings characterSettings;
        CharacterMovementController characterMovementController;
        
        void Awake()
        {
            characterController = GetComponent<CharacterCombatController>();
            characterSettings = GetComponent<CharacterSettings>();
            characterMovementController = GetComponent<CharacterMovementController>();
        }

        private void Update()
        {
            string hAxis      = player == Player.P1 ? "P1_Horizontal" : "P2_Horizontal";
            string vAxis      = player == Player.P1 ? "P1_Vertical"   : "P2_Vertical";
            string leftPunch  = player == Player.P1 ? "P1_LP"         : "P2_LP";
            string rightPunch = player == Player.P1 ? "P1_RP"         : "P2_RP";
            string leftKick   = player == Player.P1 ? "P1_LK"         : "P2_LK";
            string rightKick  = player == Player.P1 ? "P1_RK"         : "P2_RK";
            
            //Stick direction
            var h = Input.GetAxisRaw(hAxis);
            var v = Input.GetAxisRaw(vAxis);
            var facing = DetectFacing(h, v);

            characterMovementController.SetMovementDirection(h);

            TryButton(Input.GetButtonDown(leftPunch), InputButton.LeftPunch, facing);
            TryButton(Input.GetButtonDown(rightPunch), InputButton.RightPunch, facing);
            TryButton(Input.GetButtonDown(leftKick), InputButton.LeftKick, facing);
            TryButton(Input.GetButtonDown(rightKick), InputButton.RightKick, facing);
        }

        FacingDirection DetectFacing(float h, float v)
        {
            if (h > 0.5f) return FacingDirection.Forward;
            if (h < -0.5f) return FacingDirection.Back;
            
            if (v < -0.5f) return FacingDirection.Down;
            if (v < -0.5f && h > 0.5f) return FacingDirection.DownForward;
            if (v < -0.5f && h < -0.5f) return FacingDirection.DownBack;
            
            if (v > 0.5f) return FacingDirection.Up;
            if (v > 0.5f && h > 0.5f) return FacingDirection.UpForward;
            if (v > 0.5f && h < -0.5f) return FacingDirection.UpBack;

            return FacingDirection.Neutral;
        }

        void TryButton(bool pressed, InputButton button, FacingDirection facing)
        {
            if (!pressed) return;
            
            //Find all moves matching button+facing
            var candidates = characterSettings.Attacks.Where(a => a.button == button && a.requiredFacing == facing);
            
            foreach (var a in candidates)
            {
                if (characterController.DoAttack(a))
                {
                    return;
                }
            }
        }
    }
}