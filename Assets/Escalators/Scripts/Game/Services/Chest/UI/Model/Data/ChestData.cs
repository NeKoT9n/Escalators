using Assets.CodeCore.Scripts.Game.Providers;
using Inventory;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Model.Chests.Data
{
    [CreateAssetMenu(menuName = "Data/Chest", fileName = nameof(ChestData))]
    public class ChestData : ScriptableObjectGameData
    {
        [SerializeField] private Sprite _defualtIcon;
        [SerializeField] private Sprite _openedIcon;

        public Sprite Defualt => _defualtIcon;
        public Sprite Opened => _openedIcon;
        public KeyTypeId Key { get; private set; }

        public void SetRandomKeyType()
        {
            var values = Enum.GetValues(typeof(KeyTypeId)).Cast<KeyTypeId>().ToArray();
            int randomIndex = UnityEngine.Random.Range(1, values.Length);

            Key = values[randomIndex];
        }

    }
}
