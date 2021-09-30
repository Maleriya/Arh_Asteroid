using UnityEngine;

namespace Asteroids
{
    internal sealed class InputUser
    {
        private readonly Camera _camera;
        private readonly Transform _transform;
        public Vector3 direction { get; private set; }
        public bool keyLeftShiftDown { get; private set; }
        public bool keyLeftShiftUp { get; private set; }
        public float horizontal { get; private set; }
        public float vertical { get; private set; }
        public bool fire1Down { get; private set; }

        public InputUser(Camera camera, Transform transform)
        {
            _camera = camera;
            _transform = transform;
        }

        public void InputUpdate()
        {
            direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            keyLeftShiftDown = Input.GetKeyDown(KeyCode.LeftShift);
            keyLeftShiftUp = Input.GetKeyUp(KeyCode.LeftShift);
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            fire1Down = Input.GetButtonDown("Fire1");
        }

    }
}
