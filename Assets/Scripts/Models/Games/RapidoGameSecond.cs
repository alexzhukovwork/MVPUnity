using Assets.Scripts.Additionals;
using Assets.Scripts.Models.Network;

namespace Assets.Scripts.Models.Games
{
    public class RapidoSecondGame : Game
    {
        public RapidoSecondGame(IContext context, IClient client) : base(context, client)
        {
        }

        public override Games Id => Games.RapidoSecond;
    }
}