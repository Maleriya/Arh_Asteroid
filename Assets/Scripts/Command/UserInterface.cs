using System.Collections.Generic;
using UnityEngine;
using Asteroids.Observer;

namespace Asteroids.Command.Second
{
    internal sealed class UserInterface : MonoBehaviour
    {
        [SerializeField] private PanelOne _panelOne;
        [SerializeField] private PanelTwo _panelDebuff;
        private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();
        private BaseUI _currentWindow;

        private void Start()
        {
            _panelOne.Cancel();
            _panelDebuff.Cancel();
            ServiceLocator.Resolve<ListenerHitShowDamage>().OnCountEnemyChange += ChangeCountEnemy;
            ServiceLocator.SetService<UserInterface>(this);
        }

        private void ChangeCountEnemy(int count)
        {
            _panelOne.ChangeText($"Уничтожено врагов {count}");
        }

        public void PanelDebuffActive()
        {
            Execute(StateUI.PanelDebuff);
        }

        public void PanelDebuffCancel()
        {
            CancelAll();
        }

        private void Execute(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }

            switch (stateUI)
            {
                case StateUI.PanelOne:
                    _currentWindow = _panelOne;
                    break;

                case StateUI.PanelDebuff:
                    _currentWindow = _panelDebuff;
                    break;

                default:
                    break;
            }

            _currentWindow.Execute();
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Execute(StateUI.PanelOne);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CancelAll();
            }
        }

        private void CancelAll()
        {
            if (_stateUi.Count > 0)
            {
                Execute(_stateUi.Pop(), false);
            }

            _panelOne.Cancel();
            _panelDebuff.Cancel();
        }
    }
}