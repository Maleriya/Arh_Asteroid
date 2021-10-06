using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Transform _mufflerTransform;
        private GameObject _mufflerClone;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Transform mufflerTransform)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerTransform = mufflerTransform;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _mufflerClone = Object.Instantiate(_muffler.MufflerInstance, _mufflerTransform.position, _mufflerTransform.rotation);
            _mufflerClone.transform.SetParent(_mufflerTransform);
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            return weapon;
        }

        protected override void ClearTrash()
        {
            GameObject.Destroy(_mufflerClone);
        }
    }
}
