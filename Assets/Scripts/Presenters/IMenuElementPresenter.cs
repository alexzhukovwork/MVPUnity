﻿using Assets.Scripts.Prefabs;

namespace Assets.Scripts.Presenters
{
    public interface IMenuElementPresenter
    {
        void SetMenuView(IMenuElementView menuView);
        void OnClick(int index);
    }
}