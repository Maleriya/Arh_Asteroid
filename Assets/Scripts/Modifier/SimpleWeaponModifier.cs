using UnityEngine;

namespace Asteroids.Modifier
{
    internal class SimpleWeaponModifier
    {
        protected SimpleWeapon _simpleWeapon;
        protected SimpleWeaponModifier Next;

        public SimpleWeaponModifier(SimpleWeapon simpleWeapon)
        {
            _simpleWeapon = simpleWeapon;
        }

        public void Add(SimpleWeaponModifier sm)
        {
            if(Next !=null)
            {
                Next.Add(sm);
            }
            else
            {
                Next = sm;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}
