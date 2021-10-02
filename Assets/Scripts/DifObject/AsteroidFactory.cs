
using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(UnitHealth hp)
        {
            Asteroid enemy = Object.Instantiate(
                Resources.Load<Asteroid>("Enemy/Asteroid")
                , Vector3.one
                , Quaternion.identity);
            enemy.SetHealth(hp);
            return enemy;
        }
    }
}
