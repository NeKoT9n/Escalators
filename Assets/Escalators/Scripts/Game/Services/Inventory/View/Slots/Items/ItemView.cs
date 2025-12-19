using Assets.CodeCore.Scripts.Game.UI.Base;
using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemView : UIBase, IWorldView
    {
        [SerializeField] private Image _icon;
        public GameObject GameObject => gameObject;

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }
    }
}
