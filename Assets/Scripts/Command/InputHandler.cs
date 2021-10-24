using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Command
{
    internal sealed class InputHandler : MonoBehaviour
    {
        [SerializeField] private Transform _box;
        [SerializeField] private float _moveDistance;
        private ICommand _buttonW;
        private ICommand _buttonS;

        private ICommand _buttonB;
        private ICommand _buttonZ;
        private readonly List<ICommand> _oldCommands = new List<ICommand>();

        private void Start()
        {
            _buttonB = new DoNothing();
            _buttonW = new MoveForward(_moveDistance);
            _buttonS = new MoveReverse(_moveDistance);

            _buttonZ = new UndoCommand(_oldCommands);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (_buttonB.Execute(_box))
                {
                    _oldCommands.Add(_buttonB);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (_buttonS.Execute(_box))
                {
                    _oldCommands.Add(_buttonS);
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (_buttonW.Execute(_box))
                {
                    _oldCommands.Add(_buttonW);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                _buttonZ.Execute(_box);
            }
        }
    }
}