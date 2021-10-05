using UnityEngine;

namespace Asteroids
{
    public sealed class UnitHealth
    {
        private float _hpCurrent;
        public float hpCurrent
        {
            get => _hpCurrent;
            set
            {
                _hpCurrent = value;
                if (_hpCurrent <= 0.0f)
                    ThisDeath();
            }
        }
        public float hpMax;
        private GameObject _gameObject;

        public event System.Action ThisDeath = delegate { };

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
