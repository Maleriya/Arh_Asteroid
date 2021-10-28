using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    internal sealed class DifWeapon : IWeapon
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private readonly float _force;

        public DifWeapon(Transform barrel, float force)
        {
            _barrel = barrel;
            _force = force;
        }

        public void Fire()
        {
            CreateBullet();
        }

        private void CreateBullet()
        {
            Bullet bullet = ServiceLocator.Resolve<BulletPool>().GetBullet("Blast");
            bullet.ActiveBullet(_barrel.rotation, _barrel.position);
            bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _force);
        }

    }
}
