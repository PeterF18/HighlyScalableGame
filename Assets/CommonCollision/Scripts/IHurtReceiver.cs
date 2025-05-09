using UnityEngine;

namespace CommonCollision.Scripts
{
    public interface IHurtReceiver
    {
        bool IsBlocking(Vector2 hitDirection);
        
        void ReceiveHit(int damage, Vector2 hitDirection);
    }
}