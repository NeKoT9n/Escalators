using Assets.Escalators.Scripts.Game.Services.Chest.Model.Inventory.Items.Data;

namespace Inventory
{
    public class Key : Item
    {
        public KeyTypeId Type => Type;

        private readonly KeyData _keyData;

        public Key(KeyData keyData) : base(keyData)
        {
            _keyData = keyData;
        }
    }
}
