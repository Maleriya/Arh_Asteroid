namespace Asteroids.Modifier
{
    internal sealed class AddAttackModifier : SimpleWeaponModifier
    {
        private readonly int _attack;

        public AddAttackModifier(SimpleWeapon simpleWeapon, int attack)
            :base(simpleWeapon)
        {
            _attack = attack;
        }

        public override void Handle()
        {
            _simpleWeapon.Attack += _attack;
            base.Handle();
        }
    }
}
