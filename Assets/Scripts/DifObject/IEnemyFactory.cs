using UnityEngine;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy Create(UnitHealth hp);
    }
}
