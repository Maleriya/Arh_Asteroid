using UnityEngine;

namespace Asteroids
{
    public interface IBulletFactory
    {
        Bullet Create(float damage);
    }
}
