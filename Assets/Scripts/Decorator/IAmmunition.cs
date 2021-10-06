using UnityEngine;

namespace Asteroids.Decorator
{
    internal interface IAmmunition
    {
        Rigidbody2D BulletInstance { get; }
        float TimeToDestroy { get; }
    }
}