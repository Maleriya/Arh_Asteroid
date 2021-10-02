using UnityEngine;

namespace Asteroids
{
    public sealed class UnitHealth
    {
        public float hpCurrent;
        public float hpMax;
        private GameObject _gameObject;

        public UnitHealth(float startHp, GameObject gameObject)
        {
            hpCurrent = startHp;
            _gameObject = gameObject;
        }

        public UnitHealth(float startHp)
        {
            hpMax = startHp;
            hpCurrent = hpMax;
        }

        public void ChangeCurrentHP(Collision2D other)
        {
            if (hpCurrent <= 0)
            {
                Death();
            }
            else
            {
                hpCurrent--;
            }
        }

        private void Death()
        {
            Object.Destroy(_gameObject);
        }

    }
}
