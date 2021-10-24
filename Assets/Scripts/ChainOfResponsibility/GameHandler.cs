using UnityEngine;

namespace Asteroids.ChainOfResponsibility
{
    public abstract class GameHandler : MonoBehaviour, IGameHandler
    {
        private IGameHandler _nextHandler;

        public virtual IGameHandler Handle()
        {
            if (_nextHandler != null)
                _nextHandler.Handle();

            return _nextHandler;
        }

        public IGameHandler SetNext(IGameHandler handler)
        {
            _nextHandler = handler;
            return _nextHandler;
        }
    }
}
