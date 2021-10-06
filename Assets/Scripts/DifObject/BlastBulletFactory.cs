
using UnityEngine;
using Asteroids.Builder;

namespace Asteroids
{
    public sealed class BlastBulletFactory : IBulletFactory
    {
        public Bullet Create(float damage)
        {
            Sprite sprite = Resources.Load<Sprite>("Bullet/Blast");

            var gameObjectBuilder = new GameObjectBuilder();
            BlastBullet simpleBullet = gameObjectBuilder
                .Visual
                .Name("Blast" + GameManager.numBullet)
                .Sprite(sprite)
                .Physics
                .RigidBody2D(1, 0)
                .BoxCollider2D()
                ._gameObject
                .AddComponent<BlastBullet>();

            GameManager.IncremNumBullet();
            simpleBullet.SetDamage(10);
            return simpleBullet;
        }
    }
}
