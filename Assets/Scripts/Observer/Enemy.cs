using System;
using UnityEngine;

namespace Asteroids.Observer
{
    public sealed class Enemy : MonoBehaviour, IHit
    {
        public event Action<Type, float> OnHitChange = delegate (Type t,float f) { };

        public void Hit(Type type, float damage)
        {
            OnHitChange.Invoke(type, damage);
        }
    }
}
