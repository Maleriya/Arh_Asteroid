using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy, IActivateEnemy
    {
        public void Activate(IVisitor value)
        {
            value.Visit(this);
        }

        private void Update()
        {
            if (gameObject.transform.position.y >= GameManager.screenXYMax.y)
            {
                //Debug.Log($"Asteroid Update{gameObject.name} - {gameObject.activeSelf}");
                Health.hpCurrent = 0;
            }

            Move.Move(0.0f, 1.0f, Time.deltaTime);
        }
    }
}
