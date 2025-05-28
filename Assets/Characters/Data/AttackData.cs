using System.Collections.Generic;
using CommonCharacter.Data;
using CommonCharacter.Scripts;
using UnityEngine;

namespace Characters.Data
{
    [CreateAssetMenu(menuName = "Character/AttackData")]
    public class AttackData : ScriptableObject, IAttackData
    {
        [Header("Identity")]
        [SerializeField] private string             attackName;               //Attack Name
        [SerializeField] private InputButton        button;                   //Which key press
        [SerializeField] private FacingDirection    requiredFacing;           //What direction the stick must be at
        
        [Header("Combo")]
        [SerializeField] private bool               isComboRoot = false;      //Boolean for attacks that can be thrown from neutral
        [SerializeField] private AttackData[]       comboFollowUps;           //What may follow *this* attack
        
        [Header("Timing & Damage")]
        [SerializeField] private int                startupFrames;            //e.g. 14
        [SerializeField] private int                recoveryOnHit;            //Frames on hit
        [SerializeField] private int                recoveryOnBlock;          //Frames on block
        [SerializeField] private int                damage;

        [Header("Hitbox Settings")]
        [SerializeField] private Vector2 hitboxSize    = new Vector2(1, 1);
        [SerializeField] private Vector2 hitboxOffset  = Vector2.zero;

        
        //Getters
        public string AttackName                           => attackName;
        public InputButton Button                          => button;
        public FacingDirection RequiredFacing              => requiredFacing;
        public bool IsComboRoot                            => isComboRoot;
        public IEnumerable<IAttackData> ComboFollowUps     => comboFollowUps;
        public int StartupFrames                           => startupFrames;
        public int RecoveryOnHit                           => recoveryOnHit;
        public int RecoveryOnBlock                         => recoveryOnBlock;
        public int Damage                                  => damage;
        public Vector2 HitboxSize                          => hitboxSize;
        public Vector2 HitboxOffset                        => hitboxOffset;
    }
}