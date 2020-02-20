using System;
using System.Linq;
using Assets.Scripts.Models.Games;
using Zenject;

namespace Assets.Scripts.Presenters
{
    public class GamePresenter : IGamePresenter
    {
        public IGameView GameView { get; set; }

        [Inject]
        private IGame[] Games { get; set; }

        private IGame CurrentGame { get; set; }

        public void SelectGame(IGameView gameView)
        {
            GameView = gameView;

            CurrentGame = Games.First(x => x.Id == GameView.GameId);

            CurrentGame.Select();
        }
    }
}