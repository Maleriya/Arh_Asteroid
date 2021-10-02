using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        Enemy enemy;
        [SerializeField] private Transform[] generatePoint;
        public EnemyPool enemyPool;
        private float time;
        private float delta;

        private void Start()
        {
            GameManager.screenXYMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            GameManager.screenXYMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            GameManager.generatePoint = generatePoint;

            delta = 1.0f;
            enemyPool = new EnemyPool(5);       
        }

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {   
                enemy = enemyPool.GetEnemy("Asteroid");
                enemy.ActiveEnemy(Quaternion.identity);
                time = delta;
            }
        }

    }
}
