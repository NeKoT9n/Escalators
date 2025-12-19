using Assets.Escalators.Scripts.Core.Abstractions.View.IWorldView;
namespace Inventory
{
    public interface ISlotView : IWorldView
    {
        public bool CanAdd(Item item);
    }
}
