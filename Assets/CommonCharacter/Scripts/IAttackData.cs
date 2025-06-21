using System.Collections.Generic;
using CommonCharacter.Data;
using UnityEngine;

namespace CommonCharacter.Scripts
{
    public interface IAttackData
    {
        string                   AttackName      { get; }  //Attack Name
        InputButton              Button          { get; }  //Which key press
        FacingDirection          RequiredFacing  { get; }  //What direction the stuck must be at
        bool                     IsComboRoot     { get; }  //Boolean for attacks that can be thrown from neutral
        IEnumerable<IAttackData> ComboFollowUps  { get; }  //What may follow *this* attack
        int                      StartupFrames   { get; }  //e.g. 14
        int                      RecoveryOnHit   { get; }  //Frames on hit
        int                      RecoveryOnBlock { get; }  //Frames on block
        int                      Damage          { get; }
        Vector2                  HitboxSize      { get; }
        Vector2                  HitboxOffset    { get; }
    }
}