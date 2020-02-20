using System;
using Assets.Scripts.Prefabs;
using Assets.Scripts.Presenters;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Views.MenuElements
{
    public class MenuElementView : MonoBehaviour, IMenuElementView
    {
        [SerializeField] 
        protected Button _Button;

        [SerializeField] 
        protected GameObject _Highlight;

        [Inject]
        private IMenuElementPresenter Presenter { get; set; }

        private static int _number;

        private int _index;


        private IGameView GameView { get; set; }

        public GameObject GameObject => gameObject;

        public Action OnClick { get; set; }

        private void Start()
        {
            _Button.onClick.AddListener(OnClickListener);
        }

        protected void OnClickListener()
        {
            OnClick?.Invoke();
        }

        public void Select()
        {
            _Highlight.SetActive(true);

            GameView.Select();
        }

        public void Unselect()
        {
            _Highlight.SetActive(false);

            GameView.Unselect();
        }

        [Inject]
        public void SetGameView(IGameView[] gameView)
        {
            GameView = gameView[_number++];
            GameView.Select();
        }
    }
}