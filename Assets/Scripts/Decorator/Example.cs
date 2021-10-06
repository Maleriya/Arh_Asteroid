using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;
        private bool _isClearFire;

        [Header("Start Gun")]
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        private Weapon clearFire;
        private IAmmunition ammunition;
        private ModificationMuffler modificationWeapon;

        private void Start()
        {
            ammunition = new Bullet(_bullet, 3.0f);
            clearFire = new Weapon(ammunition, _barrelPosition, 900.0f, _audioSource, _audioClip);

            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPositionMuffler, _muffler);
            modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler);

            _fire = clearFire;
            _isClearFire = true;
        }

        private void ResetWeapon()
        {
            modificationWeapon.ApplyClearTrash();
            clearFire.SetBarrelPosition(_barrelPosition);
            clearFire.SetBullet(ammunition);
            clearFire.SetForce(900.0f);
            clearFire.SetAudioClip(_audioClip);
            _fire = clearFire;
        }

        private void SetMuffler()
        {
            modificationWeapon.ApplyModification(clearFire);
            _fire = modificationWeapon;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                if(_isClearFire)
                {
                    SetMuffler();
                    _isClearFire = false;
                }
                else
                {
                    ResetWeapon();
                    _isClearFire = true;
                }
            }

            if(Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }
    }
}
