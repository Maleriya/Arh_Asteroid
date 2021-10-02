using System;
using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        private Transform _rotPool;
        private UnitHealth _unitHealth;
        private MoveTransform _move;

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
        }

        public void ActiveEnemy(Quaternion rotation)
        {
            int generatePoint = UnityEngine.Random.Range(0, GameManager.generatePoint.Length - 1);
            transform.localPosition = GameManager.generatePoint[generatePoint].position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }
    }
}
