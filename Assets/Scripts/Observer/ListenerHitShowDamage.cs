using System;
using UnityEngine;

namespace Asteroids.Observer
{
    public sealed class ListenerHitShowDamage
    {
        private int _countEnemy = 0;

        public int CountEnemy { get => _countEnemy; private set { _countEnemy = value; } }

        public void Add(IHit value)
        {
            value.OnHitChange += ValueOnHitChange;
        }

        public void Remove(IHit value)
        {
            value.OnHitChange -= ValueOnHitChange;
        }

        private void ValueOnHitChange(Type type, float damage)
        {
            Debug.Log($"Уничтожен {type.Name} {damage}");
            CountEnemyChange(1);
        }

        public event Action<int> OnCountEnemyChange = delegate (int a) { };

        public void CountEnemyChange(int a)
        {
            CountEnemy += a;
            OnCountEnemyChange.Invoke(CountEnemy);
        }
    }
}
