
namespace Assets.Escalators.Scripts.Game.Services.DragAndDrop
{
    public interface IDragService
    {
        public void StartDrag(DragData information);
        public void EndDrag();
        public DragData? Peek();
        
    }

}
