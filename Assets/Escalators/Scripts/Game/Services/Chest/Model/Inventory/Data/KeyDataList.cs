using Assets.CodeCore.Scripts.Game.Providers;
using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data
{
    [CreateAssetMenu(menuName = "Data/InventoryItems/KeyDataList", fileName = nameof(KeyDataList))]
    public class KeyDataList : ScriptableObjectGameData
    {
        [SerializeField] private List<KeyData> _keyDatas;
        public IReadOnlyList<KeyData> Keys => _keyDatas;
    }
}
