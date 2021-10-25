using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.Command
{
    internal sealed class PanelOne : BaseUI
    {
        [SerializeField] private Text _text;

        public override void Execute()
        {         
            gameObject.SetActive(true);
        }

        public void ChangeText(string str)
        {
            _text.text = str;
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}
