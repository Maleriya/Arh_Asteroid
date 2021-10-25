using UnityEngine;
using Asteroids.Pool;
using System.Collections.Generic;
using Asteroids.Observer;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Transform[] asteroidPoint;
        [SerializeField] private Transform[] kometaPoint;
        private float time;
        private float delta;

        [Header ("MyDictionary")]
        [SerializeField] private List<Enemy> keys;
        [SerializeField] private List<int> values;

        private Dictionary<Enemy, int> dictionaryEnemy;

        public void AddToDictionary(Enemy type, int count)
        {
            if (!dictionaryEnemy.ContainsKey(type))
            {
                dictionaryEnemy.Add(type, count);
                keys.Add(type);
                values.Add(count);
            }
            else
            {
                dictionaryEnemy[type] += count;
                values[keys.FindIndex(a => a == type)] += count;
            }
        }

        private void Start()
        {
            GameManager.screenXYMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            GameManager.screenXYMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            GameManager.asteroidPoint = asteroidPoint;
            GameManager.kometaPoint = kometaPoint;

            delta = 1.0f;
            ServiceLocator.SetService<EnemyPool>(new EnemyPool(3));
            ServiceLocator.SetService<BulletPool>(new BulletPool(10));
            ServiceLocator.SetService<ListenerHitShowDamage>(new ListenerHitShowDamage());
            ServiceLocator.SetService<ConsoleLogVisitor>(new ConsoleLogVisitor());
            time = delta;

            dictionaryEnemy = new Dictionary<Enemy, int>();

            keys = new List<Enemy>();
            values = new List<int>();
        }

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                int generatePoint = UnityEngine.Random.Range(0, GameManager.asteroidPoint.Length - 1);
                Enemy asteroid = ServiceLocator.Resolve<EnemyPool>().GetEnemy("Asteroid"); 
                asteroid.ActiveEnemy(Quaternion.identity, GameManager.asteroidPoint[generatePoint].position);
                (asteroid as Asteroid).Activate(ServiceLocator.Resolve<ConsoleLogVisitor>());
                AddToDictionary(asteroid, 1);


                generatePoint = UnityEngine.Random.Range(0, GameManager.kometaPoint.Length - 1);
                Enemy kometa = ServiceLocator.Resolve<EnemyPool>().GetEnemy("Kometa");
                kometa.ActiveEnemy(Quaternion.identity, GameManager.kometaPoint[generatePoint].position);
                (kometa as Kometa).Activate(ServiceLocator.Resolve<ConsoleLogVisitor>());
                AddToDictionary(kometa, 1);

                time = delta;
            }
        }

    }
}
