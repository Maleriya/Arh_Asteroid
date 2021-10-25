using UnityEngine;

namespace Asteroids.Visitor
{
    public sealed class ApplayDamage : IDealingDamage
    {
        public void Visit(Enemy hit, InfoCollision info)
        {
            hit.Heatth -= info.Damage;
            hit.TextMesh.text = hit.Heatth.ToString();
        }

        public void Visit(Environment hit, InfoCollision info)
        {
            
        }

        public void Visit(Knight hit, InfoCollision info)
        {
            var realDamage = info.Damage - hit.Armor;
            if (realDamage > 0)
                hit.Heatth -= realDamage;
            hit.TextMesh.text = hit.Heatth.ToString();
        }
    }
}

