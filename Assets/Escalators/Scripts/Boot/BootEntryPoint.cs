using Assets.CodeCore.Scripts.Game.Services.SceneLoad;
using UnityEngine;
using Zenject;

namespace Assets.Escalators.Scripts.Installers
{
    public class BootEntryPoint : MonoBehaviour
    {
        [Inject] private SceneLoadService _loadService;

        private async void Awake()
        {
            await _loadService.LoadGameScene("1_level");
        }
    }
    
}
