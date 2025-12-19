using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Escalators.Scripts.Game.Services.Chest.View
{
    public class ChestView : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _progress;
        [SerializeField] private Image _keyIcon;

        public InventoryView InventoryView => _inventoryView;

        public void SetIcon(Sprite icon)
            => _icon.sprite = icon;

        public void SetProgress(string progress)
            => _progress.text = progress;

        public void Open()
            => _inventoryView.Hide();

        public void SetKeyColor(Color color)
            => _keyIcon.color = color;
    }
}
