using System;
using UnityEngine;
using Asteroids.Pool;
using Asteroids.Observer;

namespace Asteroids
{
    [Serializable]
    public abstract class Enemy : MonoBehaviour, IHit
    {
        //public static IEnemyFactory Factory;
        private Transform _rotPool;
        private UnitHealth _unitHealth;
        private MoveTransform _move;

        public event Action<Type, float> OnHitChange;

        public MoveTransform Move
        {
            get
            {
                if (_move == null)
                {
                    _move = new MoveTransform(gameObject.transform, 4.0f);
                }

                return _move;
            }

            private set => _move = value;
        }

        public UnitHealth Health
        {
            get
            {
                if (_unitHealth == null)
                {
                    _unitHealth = new UnitHealth(20.0f, gameObject);
                }
                if (_unitHealth.hpCurrent <= 0.0f)
                {
                    ReturnToPol();
                }
                return _unitHealth;
            }

            private set => _unitHealth = value;
        }

        public Transform RotPool
        {
            get
            {
                if(_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_ENEMY);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }

        private void ReturnToPol()
        {
            //Debug.Log($"ReturnToPol {gameObject.name} - {gameObject.activeSelf}");

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);
            if(!RotPool)
            {
                Destroy(gameObject);
            }
        }

        public void SetHealth(UnitHealth hp)
        {
            Health = hp;
            Health.ThisDeath += ReturnToPol;
        }

        public void ActiveEnemy(Quaternion rotation, Vector3 position)
        {
            //Debug.Log($"ActiveEnemy{gameObject.name} - {gameObject.activeSelf}");
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {         
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                Hit(this.GetType(), bullet.Damage);
            }

            ReturnToPol();
        }

        public void Hit(Type type, float damage)
        {
            OnHitChange?.Invoke(type, damage);
        }

        private void OnEnable()
        {
            ServiceLocator.Resolve<ListenerHitShowDamage>().Add(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Resolve<ListenerHitShowDamage>().Remove(this);
        }
    }
}
