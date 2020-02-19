using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Prefabs;
using Assets.Scripts.Presenters;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Views
{
    public class MenuView : MonoBehaviour, IMenuView
    {
        [SerializeField] private Transform _Transform;

        [Inject]
        private IMenuPresenter MenuPresenter { get; set; }

        public IMenuElementView[] MenuElementViews { get; set; }

        private void Reset()
        {
            _Transform = transform;
        }

        private void Start()
        {
            MenuPresenter.SetMenuView(this);
        }

        public void SetMenuGames(IMenuElementView[] menuViews)
        {
            MenuElementViews = new IMenuElementView[menuViews.Length];

            for (int i = 0; i < menuViews.Length; i++)
            {
                MenuElementViews[i] = menuViews[i];
                
                int temp = i;

                MenuElementViews[i].GameObject.transform.SetParent(transform);

                MenuElementViews[i].OnClick += () => MenuPresenter.OnClick(temp);
            }
        }

        public void SelectElement(int index)
        {
            for (int i = 0; i < MenuElementViews.Length; i++)
            {
                if (i == index)
                    MenuElementViews[i].Select();
                else
                    MenuElementViews[i].Unselect();
            }
        }
    }
}