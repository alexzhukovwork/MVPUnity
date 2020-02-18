using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class MenuPresenter : IMenuPresenter
    {
        public IMenuView MenuView { get; set; }
        public IMenuModel MenuModel { get; set; }

        public void SetMenuView(IMenuView menuView)
        {
            MenuView = menuView;
            MenuView.SetMenuGames(MenuModel.MenuPrefabs);

            MenuView.SelectElement(0);
            MenuModel.SetCurrentElement(0);
        }

        public void OnClick(int index)
        {
            MenuModel.SetCurrentElement(index);
            MenuView.SelectElement(index);
        }

        public MenuPresenter(IMenuModel menuModel)
        {
            MenuModel = menuModel;
        }
    }
}