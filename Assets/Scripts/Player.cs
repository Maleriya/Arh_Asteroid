using System.Collections.Generic;
using UnityEngine;
using Asteroids.Pool;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _startHp;
        [SerializeField] private List<Transform> _barrel;
        [SerializeField] private float _force;

        private Camera _camera;
        private Ship _ship;
        private List<IWeapon> _weapons;
        private UnitHealth _playerHealth;
        private InputUser _inputUser;

        void Start()
        {
            _camera = Camera.main;

            var moveTransform = new AccelerationMove(transform, _startSpeed, _acceleration);
            //var moveTransform = new MoveForce(transform, _startSpeed); 

            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);

            _weapons = new List<IWeapon>();

            SimpleWeapon weapon = new SimpleWeapon(_barrel[0], _force);
            _weapons.Add(weapon);

            DifWeapon difWeapon = new DifWeapon(_barrel[1], _force);
            _weapons.Add(difWeapon);

            _playerHealth = new UnitHealth(_startHp, gameObject);
            _inputUser = new InputUser(_camera, transform);


        }

        void Update()
        {
            _inputUser.InputUpdate();

            _ship.Rotation(_inputUser.direction);
            _ship.Move(_inputUser.horizontal, _inputUser.vertical, Time.deltaTime);

            if (_inputUser.keyLeftShiftDown)
                _ship.AddAcceleration();

            if (_inputUser.keyLeftShiftUp)
                _ship.RemoveAcceleration();

            if (_inputUser.fire1Down)
            {
                foreach (var weapon in _weapons)
                {
                    weapon.CreateBullet();
                }     
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _playerHealth.ChangeCurrentHP(other);
            _startHp = _playerHealth.hpCurrent;
        }

    }
}
