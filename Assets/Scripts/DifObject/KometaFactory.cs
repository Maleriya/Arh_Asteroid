
using UnityEngine;

namespace Asteroids
{
    public sealed class KometaFactory : IEnemyFactory
    {
        public Enemy Create(UnitHealth hp)
        {
            Kometa enemy = Resources.Load<Kometa>("Enemy/Kometa");
            enemy.name = "Kometa" + GameManager.numKometa;
            GameManager.IncremNumKometa();
            enemy.SetHealth(hp);
            return enemy;
        }
    }
}

