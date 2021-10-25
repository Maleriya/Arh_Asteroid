using UnityEngine;

namespace Asteroids.State
{
    internal abstract class ShipState
    {
        Ship _ship;

        public ShipState(Ship ship)
        {
            _ship = ship;
        }

        public virtual void Move(float horizontal, float vertical, float deltaTime)
        {
            _ship.MoveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public virtual void Rotation(Vector3 direction)
        {
            _ship.RotationImplementation.Rotation(direction);
        }

        public virtual void AddAcceleration()
        {
            if (_ship.MoveImplementation is AccelerationMove accelerationMove)
                accelerationMove.AddAcceleration();
        }

        public virtual void RemoveAcceleration()
        {
            if (_ship.MoveImplementation is AccelerationMove accelerationMove)
                accelerationMove.RemoveAcceleration();
        }
    }
}
