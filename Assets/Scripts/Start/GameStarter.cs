using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Transform[] asteroidPoint;
        [SerializeField] private Transform[] kometaPoint;
        private float time;
        private float delta;

        private void Start()
        {
            GameManager.screenXYMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            GameManager.screenXYMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            GameManager.asteroidPoint = asteroidPoint;
            GameManager.kometaPoint = kometaPoint;

            delta = 1.0f;
            ServiceLocator.SetService<EnemyPool>(new EnemyPool(3));
            ServiceLocator.SetService<BulletPool>(new BulletPool(10));
            time = delta;
        }

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                int generatePoint = UnityEngine.Random.Range(0, GameManager.asteroidPoint.Length - 1);
                ServiceLocator.Resolve<EnemyPool>().GetEnemy("Asteroid").ActiveEnemy(Quaternion.identity, GameManager.asteroidPoint[generatePoint].position);

                generatePoint = UnityEngine.Random.Range(0, GameManager.kometaPoint.Length - 1);
                ServiceLocator.Resolve<EnemyPool>().GetEnemy("Kometa").ActiveEnemy(Quaternion.identity, GameManager.kometaPoint[generatePoint].position);

                time = delta;
            }
        }

    }
}
