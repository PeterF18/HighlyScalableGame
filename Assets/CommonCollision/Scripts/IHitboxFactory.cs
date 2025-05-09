using CommonCollision.Data;
using UnityEngine;

namespace CommonCollision.Scripts
{
    public interface IHitboxFactory
    {
        IHitbox CreateHitbox(HitboxInfo info, Vector2 worldPos, Transform attacker);
    }
}