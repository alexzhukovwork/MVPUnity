using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Views.Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        public GameObject GameObject => gameObject;
    
        [Inject]
        public IGamePresenter GamePresenter { get; set; }

        public void Select()
        {
            GameObject.SetActive(true);
            GamePresenter.GameView = this;
        }

        public void Unselect()
        {
            GameObject.SetActive(false);
        }
    }
}