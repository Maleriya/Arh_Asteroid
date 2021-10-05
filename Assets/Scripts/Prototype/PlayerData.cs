using System;

namespace Asteroids.Prototype
{
    [Serializable]
    class PlayerData
    {
        public float Speed;
        public HP Hp;

        public override string ToString()
        {
            return $"Speed {Speed} Hp {Hp}";
        }
    }

    [Serializable]
    class HP
    {
        public float currentHP;
        public float maxHP;

        public override string ToString()
        {
            return $"currentHP {currentHP} maxHP {maxHP}";
        }
    }
}
