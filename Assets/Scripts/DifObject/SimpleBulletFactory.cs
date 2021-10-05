
using UnityEngine;
using Asteroids.Builder;

namespace Asteroids
{
    public sealed class SimpleBulletFactory : IBulletFactory
    {
        public Bullet Create(float damage)
        {
            GameObject gameO = Resources.Load<GameObject>("Bullet/SimpleBullet");
            Sprite spr = gameO.GetComponent<SpriteRenderer>().sprite;

            Sprite sprite = Resources.Load<Sprite>("Bullet/Lazer");

            var gameObjectBuilder = new GameObjectBuilder();
            SimpleBullet simpleBullet = gameObjectBuilder
                .Visual
                .Name("Простая пуля" + GameManager.numBullet)
                .Sprite(sprite)
                .Physics
                .RigidBody2D(1, 0)
                .BoxCollider2D()
                ._gameObject
                .AddComponent<SimpleBullet>();

            GameManager.IncremNumBullet();
            simpleBullet.SetDamage(10);
            return simpleBullet;
        }
    }
}
