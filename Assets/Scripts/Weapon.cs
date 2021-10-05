using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    internal sealed class Weapon : IWeapon
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private readonly float _force;

        public Weapon(Rigidbody2D bullet, Transform barrel, float force)
        {
            _bullet = bullet;
            _barrel = barrel;
            _force = force;
        }

        public void CreateBullet()
        {

            Bullet bullet = ServiceLocator.Resolve<BulletPool>().GetBullet("Simple bullet");
            bullet.ActiveBullet(_barrel.rotation, _barrel.position);
            bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _force);
            //Rigidbody2D temAmmunition = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
            //temAmmunition.AddForce(_barrel.up * _force);
        }

    }
}
