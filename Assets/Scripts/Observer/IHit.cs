using System;

namespace Asteroids.Observer
{
    public interface IHit
    {
        event Action<Type, float> OnHitChange;
        void Hit(Type type, float damage);
    }
}
