using System;
using System.Linq;
using Assets.Scripts.Models.Games;
using Zenject;

namespace Assets.Scripts.Presenters
{
    public class GamePresenter : IGamePresenter
    {
        public IGameView GameView { get; set; }

        private IGame[] Games { get; set; }

        private IGame CurrentGame { get; set; }

        public GamePresenter(IGame[] games)
        {
            Games = games;

            for (int i = 0; i < games.Length; i++)
            {
                games[i].SetPresenter(this);
            }


        }

        public void SelectGame(IGameView gameView)
        {
            if (GameView != null)
                GameView.BetsView.RemoveListener(OnClickChangeBetView);

            GameView = gameView;

            GameView.BetsView.AddListener(OnClickChangeBetView);

            for (int i = 0; i < Games.Length; i++)
            {
                Games[i].Unselect();
            }

            CurrentGame = Games.First(x => x.Id == GameView.GameId);

            CurrentGame.Select();

            GameView.BetsView.SetView(CurrentGame.BetViewIndex);
        }

        public void SetResults(int[] results)
        {
            GameView.SetResults(results); 
        }

        private void OnClickChangeBetView()
        {
            CurrentGame.ChangeBetViewIndex();
            GameView.BetsView.SetView(CurrentGame.BetViewIndex);
        }
    }
}