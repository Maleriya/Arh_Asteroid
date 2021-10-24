using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Command
{
    internal sealed class PanelTwo : BaseUI
    {
        [SerializeField] private Text _text;

        public override void Execute()
        {
            _text.text = nameof(PanelTwo);
            gameObject.SetActive(true);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}
