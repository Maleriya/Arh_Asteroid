using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Asteroids.Pool
{
    internal sealed class BulletPool
    {
        private readonly Dictionary<string, HashSet<Bullet>> _bulletPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public BulletPool(int capacityPool)
        {
            _bulletPool = new Dictionary<string, HashSet<Bullet>>();
            _capacityPool = capacityPool;

            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
        }

        public Bullet GetBullet(string type)
        {
            Bullet result;
            switch (type)
            {
                case "Simple bullet":
                    result = GetSimpleBullet(GetListBullets(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type,
                        "Не предусмотрен в программе");
            }

            return result;
        }

        private HashSet<Bullet> GetListBullets(string type)
        {
            return _bulletPool.ContainsKey(type) ? _bulletPool[type] :
                _bulletPool[type] = new HashSet<Bullet>();
        }

        private Bullet GetSimpleBullet(HashSet<Bullet> bullets)
        {
            var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bullet == null)
            {
                IBulletFactory bulletFactory = new SimpleBulletFactory();
                var simpleBullet = bulletFactory.Create(10);

                for (int i = 0; i < _capacityPool; i++)
                {
                    var instantiate = UnityEngine.Object.Instantiate(simpleBullet);
                    ReturnToPool(instantiate.transform);
                    bullets.Add(instantiate);
                }
                GetSimpleBullet(bullets);
            }
            bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bullet;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = transform.position;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            UnityEngine.Object.Destroy(_rootPool.gameObject);
        }
    }
}
