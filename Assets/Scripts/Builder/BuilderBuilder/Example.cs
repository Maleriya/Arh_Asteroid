using UnityEngine;

namespace Asteroids.Builder
{
    internal sealed class Example : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;

        private void Start()
        {
            var gameObjectBuilder = new GameObjectBuilder();
            GameObject player = gameObjectBuilder.Visual
                .Name("Elena").Sprite(_sprite).Physics
                .RigidBody2D(0, 0).BoxCollider2D()._gameObject;
        }
    }
}
