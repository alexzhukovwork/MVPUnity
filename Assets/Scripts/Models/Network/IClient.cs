using System;

namespace Assets.Scripts.Models.Network
{
    public interface IClient
    {
        int[] GetResults();

        void SelectGame(Games.Games game);

        void OnEvent();

        void AddListener(Action<int[]> callBack);

        void RemoveListener(Action<int[]> callBack);
    }
}
