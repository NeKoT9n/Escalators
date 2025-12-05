using Cysharp.Threading.Tasks;
using UniRx;

namespace Assets.Escalators.Scripts.Core.Utils.Extentions
{
    public static class ReactiveCommandAwaitableExtensions
    {
        public static UniTask ExecuteAwaitable<T>(this IReactiveCommand<T> command, T parameter)
         where T : IUniTaskCommand
        {
            command.Execute(parameter);
            return parameter.Completion.Task;
        }
    }

    public interface IUniTaskCommand
    {
        UniTaskCompletionSource Completion { get; }
    }
}
