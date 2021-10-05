
using UnityEngine;

namespace Asteroids
{
    public sealed class SimpleBulletFactory : IBulletFactory
    {
        public Bullet Create(float damage)
        {
            SimpleBullet simpleBullet = Resources.Load<SimpleBullet>("Bullet/SimpleBullet");
            simpleBullet.name = "Простая пуля" + GameManager.numBullet;
            GameManager.IncremNumBullet();
            simpleBullet.SetDamage(10);
            return simpleBullet;
        }
    }
}
