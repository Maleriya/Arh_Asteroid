using UnityEngine;

namespace Asteroids.Decorator
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;
        protected abstract Weapon AddModification(Weapon weapon);

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        protected abstract void ClearTrash();

        public void ApplyClearTrash()
        {
            ClearTrash();
        }


        public void Fire()
        {
            _weapon.Fire();
        }
    }
}
