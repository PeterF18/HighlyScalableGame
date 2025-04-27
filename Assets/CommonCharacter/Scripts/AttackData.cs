using UnityEngine;

namespace CommonCharacter.Scripts
{
    public enum InputButton { LeftPunch, RightPunch, LeftKick, RightKick } //Just add if I have missed some
    public enum FacingDirection { 
        Neutral, 
        Forward,
        Back, 
        Down, DownForward, DownBack,
        Up, UpForward, UpBack, 
    }
    
    [CreateAssetMenu(menuName = "CommonCharacter/AttackData")]
    public class AttackData : ScriptableObject
    {
        public string             attackName;                     //Attack Name
        public InputButton        button;                   //Which key press
        public FacingDirection    requiredFacing;           //What the stuck must be at
        public bool               isComboRoot = false;      //Boolean for attacks that can be thrown from neutral
        public AttackData[]       comboFollowUps;           //What may follow *this* attack
        public int                startupFrames;            //e.g. 14
        public int                recoveryOnHit;            //Frames on hit
        public int                recoveryOnBlock;          //Frames on block
        public int                damage;

    }
}