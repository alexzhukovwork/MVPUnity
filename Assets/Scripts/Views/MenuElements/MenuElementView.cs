using System;
using Assets.Scripts.Prefabs;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views.MenuElements
{
    public abstract class MenuElementView : MonoBehaviour, IMenuElementView
    {
        [SerializeField] protected Button _Button;
        [SerializeField] protected GameObject _Highlight;
        [SerializeField] protected GameObject _GameView;
        
        public GameObject GameObject => gameObject;

        public Action OnClick { get; set; }

        public GameObject IGameView => _GameView;

        private void Awake()
        {
            _Button.onClick.AddListener(OnClickListener);

            _GameView = Instantiate(_GameView, GetComponentInParent<Canvas>().transform);

            _GameView.SetActive(false);
        }

        protected void OnClickListener()
        {
            OnClick?.Invoke();
        }

        public void Select()
        {
            _Highlight.SetActive(true);

            _GameView.SetActive(true);
        }

        public void Unselect()
        {
            _Highlight.SetActive(false);

            _GameView.SetActive(false);
        }
    }
}