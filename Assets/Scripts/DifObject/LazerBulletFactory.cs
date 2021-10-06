
using UnityEngine;
using Asteroids.Builder;

namespace Asteroids
{
    public sealed class LazerBulletFactory : IBulletFactory
    {
        public Bullet Create(float damage)
        {
            Sprite sprite = Resources.Load<Sprite>("Bullet/Lazer");

            var gameObjectBuilder = new GameObjectBuilder();
            LazerBullet simpleBullet = gameObjectBuilder
                .Visual
                .Name("Lazer" + GameManager.numBullet)
                .Sprite(sprite)
                .Physics
                .RigidBody2D(1, 0)
                .BoxCollider2D()
                ._gameObject
                .AddComponent<LazerBullet>();

            GameManager.IncremNumBullet();
            simpleBullet.SetDamage(10);
            return simpleBullet;
        }
    }
}
