using UnityEngine;

namespace Asteroids
{
    internal class MoveForce : IMove
    {
        private readonly Rigidbody2D _rigidbody2D;
        private Vector2 _move;
        public float Speed { get; protected set; }

        public MoveForce(Transform transform, float speed)
        {
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move = new Vector2(horizontal, vertical);
            _rigidbody2D.AddForce(_move * Speed);
        }
    }
}
