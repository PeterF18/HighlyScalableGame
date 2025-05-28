using System.Linq;
using Characters.Data;
using CommonCharacter.Data;
using UnityEngine;

namespace Characters.Scripts
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
        
        private string hAxis, vAxis, leftPunch, rightPunch, leftKick, rightKick;
        
        public float HorizontalInput { get; private set; }
        public FacingDirection CurrentFacing { get; private set; }
        
        //+1 for face towards right, -1 for face towards left
        public float FacingSign => transform.localScale.x > 0 ? 1f : -1f;
        
        //Horizontal input mapping where positive is forward and negative is backwards
        public float RelativeHorizontal => HorizontalInput * FacingSign;
        
        void Awake()
        {
            characterController = GetComponent<CharacterCombatController>();
            characterSettings = GetComponent<CharacterSettings>();
            characterMovementController = GetComponent<CharacterMovementController>();
            
            hAxis      = player == Player.P1 ? "P1_Horizontal" : "P2_Horizontal";
            vAxis      = player == Player.P1 ? "P1_Vertical"   : "P2_Vertical";
            leftPunch  = player == Player.P1 ? "P1_LP"         : "P2_LP";
            rightPunch = player == Player.P1 ? "P1_RP"         : "P2_RP";
            leftKick   = player == Player.P1 ? "P1_LK"         : "P2_LK";
            rightKick  = player == Player.P1 ? "P1_RK"         : "P2_RK";
        }

        private void Update()
        { 
            //Stick direction
            var h = Input.GetAxisRaw(hAxis);
            var v = Input.GetAxisRaw(vAxis);
            var facing = DetectFacing(h, v);

            HorizontalInput = h;
            CurrentFacing = facing;

            characterMovementController.SetMovementDirection(h);

            TryButton(Input.GetButtonDown(leftPunch), InputButton.LeftPunch, facing);
            TryButton(Input.GetButtonDown(rightPunch), InputButton.RightPunch, facing);
            TryButton(Input.GetButtonDown(leftKick), InputButton.LeftKick, facing);
            TryButton(Input.GetButtonDown(rightKick), InputButton.RightKick, facing);
        }

        public FacingDirection RelativeFacing
        {
            get
            {
                var f = CurrentFacing;
                if (FacingSign < 0)
                {
                    return f switch
                    {
                        FacingDirection.Forward => FacingDirection.Back,
                        FacingDirection.Back => FacingDirection.Forward,
                        FacingDirection.UpForward => FacingDirection.UpBack,
                        FacingDirection.UpBack => FacingDirection.UpForward,
                        FacingDirection.DownForward => FacingDirection.DownBack,
                        FacingDirection.DownBack => FacingDirection.DownForward,
                        _ => f
                    };
                }
                return f;
            } 
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
            var candidates = characterSettings.Attacks.Where(a => a.Button == button && a.RequiredFacing == facing);
            
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