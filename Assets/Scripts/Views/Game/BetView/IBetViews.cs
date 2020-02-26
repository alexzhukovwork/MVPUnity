using System;

namespace Assets.Scripts.Views.Game.BetView
{
    public interface IBetsView
    {
        void SetView(int i);

        void AddListener(Action onClick);

        void RemoveListener(Action onClick);
    }
}