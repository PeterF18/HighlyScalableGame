using System;
using CommonCollision.Data;
using UnityEngine;

namespace CommonCollision.Scripts
{
    //A running hitbox instance: raises an event when it collides
    public interface IHitbox
    {
        //For the first time this hitbox touches something it can collide with
        event Action<Collider2D, HitboxInfo> OnTriggered;

        //To remove the hitbox again after its active window
        void Destroy();
    }
}