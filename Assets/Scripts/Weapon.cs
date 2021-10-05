using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    internal sealed class Weapon : IWeapon
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private readonly float _force;
        private BulletPool _pool;

        public Weapon(Rigidbody2D bullet, Transform barrel, float force, BulletPool pool)
        {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
            _pool = pool;
        }

        public void CreateBullet()
        {
            Bullet bullet = _pool.GetBullet("Simple bullet");
            bullet.ActiveBullet(Quaternion.identity, _barrel.position);
            bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _force);
            //Rigidbody2D temAmmunition = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
            //temAmmunition.AddForce(_barrel.up * _force);
        }

    }
}
