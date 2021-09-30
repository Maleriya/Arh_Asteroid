using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _startSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _startHp;
        [SerializeField] private List<Rigidbody2D> _bullet;
        [SerializeField] private List<Transform> _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Ship _ship;
        private List<IWeapon> _weapons;
        private PlayerHealth _playerHealth;
        private InputUser _inputUser;

        void Start()
        {
            _camera = Camera.main;

            var moveTransform = new AccelerationMove(transform, _startSpeed, _acceleration);
            //var moveTransform = new MoveForce(transform, _startSpeed); 

            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);

            _weapons = new List<IWeapon>();
            for (int i = 0; i < _barrel.Count; i++)
            {
                Weapon weapon = new Weapon(_bullet[i], _barrel[i], _force);
                _weapons.Add(weapon);
            }

            _playerHealth = new PlayerHealth(_startHp, gameObject);
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
            _playerHealth.ColisionHappend(other);
        }

    }
}
