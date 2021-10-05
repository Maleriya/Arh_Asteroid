using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        Enemy enemy;
        [SerializeField] private Transform[] asteroidPoint;
        [SerializeField] private Transform[] kometaPoint;
        public EnemyPool enemyPool;
        private float time;
        private float delta;


        private void Start()
        {
            GameManager.screenXYMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            GameManager.screenXYMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            GameManager.asteroidPoint = asteroidPoint;
            GameManager.kometaPoint = kometaPoint;

            delta = 1.0f;
            enemyPool = new EnemyPool(3);

            time = delta;
        }

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                enemy = enemyPool.GetEnemy("Asteroid");
                int generatePoint = UnityEngine.Random.Range(0, GameManager.asteroidPoint.Length - 1);
                enemy.ActiveEnemy(Quaternion.identity, GameManager.asteroidPoint[generatePoint].position);

                enemy = enemyPool.GetEnemy("Kometa");
                generatePoint = UnityEngine.Random.Range(0, GameManager.kometaPoint.Length - 1);
                enemy.ActiveEnemy(Quaternion.identity, GameManager.kometaPoint[generatePoint].position);

                time = delta;
            }
        }

    }
}
