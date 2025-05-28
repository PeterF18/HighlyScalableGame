using Characters.Scripts;
using UnityEngine;

namespace Characters.Data
{
    [RequireComponent(
        typeof(CharacterSettings),
        typeof(CharacterStateController),
        typeof(CharacterCombatController))]
    [RequireComponent(
        typeof(CharacterMovementController),
        typeof(CharacterBlockController))]
    public class CharacterRoot : MonoBehaviour
    {
        //Just an empty class that makes it easy to put all the needed controllers on a .prefab character with a single MonoBehaviour.
    }
}