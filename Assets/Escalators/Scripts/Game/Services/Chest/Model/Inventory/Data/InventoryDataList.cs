using Assets.CodeCore.Scripts.Game.Providers;
using Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Data
{
    [CreateAssetMenu(menuName = "Data/Inventory/List", fileName = nameof(InventoryDataList))]
    public class InventoryDataList : ScriptableObjectGameData
    {
        [SerializeField] private List<InventoryData> _datas;

        public IReadOnlyCollection<InventoryData> Datas => _datas;
    }
}
