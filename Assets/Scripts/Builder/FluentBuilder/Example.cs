using UnityEngine;

namespace Asteroids.FluentBuilder
{
    internal sealed class Example : MonoBehaviour
    {
        [SerializeField] private Sprite _sprite;

        private void Start()
        {
            new GameObject().SetName("Elena_FluentBuilder")
                .AddBoxCollider2D()
                .AddRigitBody2D(0)
                .AddSprite(_sprite);
        }
    }
}
