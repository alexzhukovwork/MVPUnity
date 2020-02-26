using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models.Games;
using Assets.Scripts.Views.Game.BetView;
using Assets.Scripts.Views.Game.ResultView;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Views.Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private Models.Games.Games _GameId;
     
        private IResultsView _resultsView;
        private IBetsView _betsView;

        public GameObject GameObject => gameObject;

        public IBetsView BetsView { get => _betsView; }

        [Inject]
        public IGamePresenter GamePresenter { get; set; }

        public Games GameId => _GameId;

        private void Awake()
        {
            _resultsView = GetComponentInChildren<IResultsView>();
            _betsView = GetComponentInChildren<IBetsView>();
        }

        public void Select()
        {
            GameObject.SetActive(true);
            GamePresenter.SelectGame(this);
        }

        public void Unselect()
        {
            GameObject.SetActive(false);
        }

        public void SetResults(int[] results)
        {
            _resultsView.SetResults(results);
        }
    }
}