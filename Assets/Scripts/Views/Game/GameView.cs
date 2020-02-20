using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models.Games;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Views.Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private GameObject[] _Results;
        [SerializeField] private Models.Games.Games _GameId;

        public GameObject GameObject => gameObject;

        [Inject]
        public IGamePresenter GamePresenter { get; set; }

        public Models.Games.Games GameId => _GameId;

        public void SetResultCount(int count)
        {

            for (int i = 0; i < count && i < _Results.Length; i++) {
                _Results[i].SetActive(true);
            }
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
    }
}