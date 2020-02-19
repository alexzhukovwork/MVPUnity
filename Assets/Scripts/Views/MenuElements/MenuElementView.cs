using System;
using Assets.Scripts.Prefabs;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Views.MenuElements
{
    public class MenuElementView : MonoBehaviour, IMenuElementView
    {
        [SerializeField] protected Button _Button;
        [SerializeField] protected GameObject _Highlight;
        
        [Inject]
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

            GameView?.GamePresenter.SetGameView(GameView);

            GameView?.GameObject.SetActive(true);
        }

        public void Unselect()
        {
            _Highlight.SetActive(false);

            GameView?.GameObject.SetActive(false);
        }

        public void Initialize()
        {
            GameView.GameObject.transform.SetParent(GetComponentInParent<Canvas>().transform);
            GameView.GameObject.SetActive(false);
        }
    }
}