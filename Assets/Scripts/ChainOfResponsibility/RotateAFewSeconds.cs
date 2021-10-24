using System.Collections;
using UnityEngine;

namespace Asteroids.ChainOfResponsibility
{
    public sealed class RotateAFewSeconds : GameHandler
    {
        [SerializeField] private float _rotationSpeed = 10.0f;
        [SerializeField] private float _rotationDuration = 3.0f;

        private IEnumerator StartRotation()
        {
            var t = 0.0f;
            while(t<_rotationDuration)
            {
                t += Time.deltaTime;
                transform.Rotate(Vector3.forward * (_rotationSpeed * Time.deltaTime));
                yield return null;
            }
            base.Handle();
        }

        public override IGameHandler Handle()
        {
            StartCoroutine(StartRotation());
            return this;
        }
    }
}
