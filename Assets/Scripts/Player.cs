using System.Collections.Generic;
using UnityEngine;
using Asteroids.Modifier;
using System;

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

            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);

            _weapons = new List<IWeapon>();

            SimpleWeapon weapon = new SimpleWeapon(_barrel[0], _force);
            _weapons.Add(weapon);

            var rootModifWeapon = new SimpleWeaponModifier(weapon);
            rootModifWeapon.Add(new AddAttackModifier(weapon, 3));
            rootModifWeapon.Add(new AddAttackModifier(weapon, 5));
            rootModifWeapon.Handle();

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
                    weapon.Fire();
                }     
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.GetComponent<Kometa>() != null)
            {
                _ship.OnDebuff();
                Invoke("ShipDisableDebuff", 5.0f);
            }

            _playerHealth.ChangeCurrentHP(other);
            _startHp = _playerHealth.hpCurrent;
        }

        private void ShipDisableDebuff()
        {
            _ship.DisableDebuff();
        }

    }
}
