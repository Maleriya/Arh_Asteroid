using UnityEngine;

namespace Asteroids.Builder
{
    internal class GameObjectBuilder
    {
        public GameObject _gameObject { get; private set; }

        public GameObjectBuilder() => _gameObject = new GameObject();

        protected GameObjectBuilder(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);
        

        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);
        
    }
}
