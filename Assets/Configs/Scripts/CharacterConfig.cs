using UnityEngine;

namespace Configs.Scripts
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [Tooltip("All the character prefabs the player can pick from")]
        public GameObject[] Options;
        
        [Tooltip("Index into Options for Player 1")] 
        public int SelectedIndex1 = 0;
        
        [Tooltip("Index into Options for Player 2 (or CPU)")] 
        public int SelectedIndex2 = 0;
        
        public GameObject SelectedPlayer1 =>
            Options != null && SelectedIndex1 >= 0 && SelectedIndex1 < Options.Length 
                ? Options[SelectedIndex1] 
                : null;
        
        public GameObject SelectedPlayer2 =>
            Options != null && SelectedIndex2 >= 0 && SelectedIndex2 < Options.Length 
                ? Options[SelectedIndex2] 
                : null;

    }
}