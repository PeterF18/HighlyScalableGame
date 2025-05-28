using System.Collections;
using CommonCharacter.Scripts;
using UnityEngine;

namespace Characters.Scripts
{
    public class CharacterStateController : MonoBehaviour, ICharacterState
    {
        private bool canAct = true;
        private Coroutine recoveryCR;
        
        public bool CanAct => canAct;
        
        public void SetRecovery(int frames)
        {
            if (recoveryCR != null) StopCoroutine(recoveryCR);
            recoveryCR = StartCoroutine(RecoveryRoutine(frames));
        }

        private IEnumerator RecoveryRoutine(int frames)
        {
            canAct = false;
            yield return new WaitForSeconds(frames / 60f);
            canAct = true;
            recoveryCR = null;
        }
    }
}