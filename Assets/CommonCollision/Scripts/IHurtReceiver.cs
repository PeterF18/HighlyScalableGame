using UnityEngine;

namespace CommonCollision.Scripts
{
    public interface IHurtReceiver
    {
        bool CanBeHit();
        
        void TakeDamage(int damage, Vector2 hitDirection);
    }
}