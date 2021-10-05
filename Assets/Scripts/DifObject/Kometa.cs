using UnityEngine;

namespace Asteroids
{
    public sealed class Kometa : Enemy
    {
        private void Update()
        {
            if (gameObject.transform.position.y >= GameManager.screenXYMax.y)
            {
                Debug.Log($"Kometa Update{gameObject.name} - {gameObject.activeSelf}");
                Health.hpCurrent = 0;
            }

            Move.Move(1.0f, 0.0f, Time.deltaTime);
        }
    }
}
