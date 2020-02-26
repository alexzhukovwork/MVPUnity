using System;
using Assets.Scripts.Additionals;
using Assets.Scripts.Models.Network;
using Zenject;

namespace Assets.Scripts.Models.Games
{
    public class RapidoGame : Game
    {
        public override Games Id => Games.Rapido;

        public RapidoGame(IContext context, IClient client)
            : base(context, client)
        {
        }
    }
}