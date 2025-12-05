using Assets.Escalators.Scripts.Game.Services.Entities.PlayerLogic;

namespace Assets.Escalators.Scripts.Game.Services.Entities.Abstractions
{
    public class SpawnCommand : UniTaskCommand
    {
        public Player Player;

        public SpawnCommand(Player player) : base()
        {
            Player = player;
        }
    }
}
