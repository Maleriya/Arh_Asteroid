
using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(UnitHealth hp)
        {
            Asteroid enemy = Resources.Load<Asteroid>("Enemy/Asteroid");
            enemy.name = "Вот и все" + GameManager.numAsteroid;
            GameManager.IncremNumAsteroid();
            enemy.SetHealth(hp);
            return enemy;
        }
    }
}
