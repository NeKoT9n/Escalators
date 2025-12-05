using Assets.Escalators.Scripts.Core.Utils.Extentions;
using Cysharp.Threading.Tasks;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public class UniTaskCommand : IUniTaskCommand
    {
        public UniTaskCommand()
        {
            Completion = new();
        }
        public UniTaskCompletionSource Completion { get; }
    }
}
