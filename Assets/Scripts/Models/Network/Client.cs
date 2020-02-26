using System;

namespace Assets.Scripts.Models.Network
{
    class Client : IClient
    {
        private int[] _results;
        private Games.Games _game;

        private event Action<int[]> _onEvent;

        public int[] GetResults()
        {
            int[] results = null; 

            switch (_game)
            {
                case Games.Games.Rapido:
                    results = GetRapidoGame();
                    break;
                case Games.Games.RapidoSecond:
                    results = GetRapidoSecondGame();
                    break;
                default:
                    break;
            }

            return results;
        }

        public int [] GetRapidoGame()
        {
            Random random = new Random();
            int count = random.Next(0, 10);

            _results = new int[count];

            for (int i = 0; i < count; i++)
            {
                _results[i] = random.Next(1, 34);
            }

            return _results;
        }

        public int [] GetRapidoSecondGame()
        {
            Random random = new Random();
            int count = random.Next(0, 10);

            _results = new int[count];

            for (int i = 0; i < count; i++)
            {
                _results[i] = random.Next(34, 55);
            }

            return _results;
        }

        public void SelectGame(Games.Games game)
        {
            _game = game;
        }

        public void OnEvent()
        {
            _onEvent?.Invoke(GetResults());
        }

        public void AddListener(Action<int[]> callBack)
        {
            _onEvent += callBack;
        }

        public void RemoveListener(Action<int[]> callBack)
        {
            _onEvent -= callBack;
        }
    }
}
