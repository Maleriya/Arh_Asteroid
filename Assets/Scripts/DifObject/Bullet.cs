using System;
using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    public abstract class Bullet : MonoBehaviour
    {
        private Transform _rotPool;
        private float _damage;
        
        public float Damage
        {
            get => _damage;
            private set => _damage = value;
        }

        public void SetDamage(float damage)
        {
            Damage = damage;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }

        private void ReturnToPol()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);
            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (gameObject.transform.position.y >= GameManager.screenXYMax.y 
                || gameObject.transform.position.y <= GameManager.screenXYMin.y
                || gameObject.transform.position.x >= GameManager.screenXYMax.x
                || gameObject.transform.position.x <= GameManager.screenXYMin.x)
            {
                ReturnToPol();
            }
        }

        public void ActiveBullet(Quaternion rotation, Vector3 position)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            ReturnToPol();
        }
    }
}
