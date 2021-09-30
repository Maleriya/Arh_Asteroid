using UnityEngine;

namespace Asteroids
{
    internal sealed class PlayerHealth
    {
        private float _hp;
        public float Hp => _hp;
        private GameObject _player;

        public PlayerHealth(float startHp, GameObject player)
        {
            _hp = startHp;
            _player = player;
        }

        public void ColisionHappend(Collision2D other)
        {
            if (_hp <= 0)
            {
                Death();
            }
            else
            {
                _hp--;
            }
        }

        private void Death()
        {
            Object.Destroy(_player);
        }

    }
}
