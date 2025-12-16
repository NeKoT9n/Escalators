
namespace Assets.Escalators.Scripts.Game.Services.DragAndDrop
{
    public interface IDragService
    {
        public void StartDrag(DragInformation information);
        public void EndDrag();
        public DragInformation? Peek();
        
    }

}
