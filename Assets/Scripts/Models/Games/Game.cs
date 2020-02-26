using Assets.Scripts.Additionals;
using Assets.Scripts.Models.Network;
using Assets.Scripts.Presenters;
using Zenject;

namespace Assets.Scripts.Models.Games
{
    public abstract class Game : IGame
    {
        protected int _betViewIndex = 0;
        protected int _betViewCount = 2;

        public abstract Games Id { get; }

        public int BetViewIndex => _betViewIndex;

        protected IGamePresenter _gamePresenter;

        protected IContext _context;

        protected IClient _client;

        public Game(IContext context, IClient client)
        {
            _context = context;
            _client = client;
        }

        public void Select()
        {
            _client.AddListener(_gamePresenter.SetResults);

            _client.SelectGame(Id);

            UpdateResults();

            _context.Logger.Log($"Selected: {this.ToString()}");
        }

        public void Unselect()
        {
            _client.RemoveListener(_gamePresenter.SetResults);
        }

        public void SetPresenter(GamePresenter gamePresenter)
        {
            _gamePresenter = gamePresenter;
        }

        public void UpdateResults()
        {
            _gamePresenter.SetResults(_client.GetResults());
        }

        public void ChangeBetViewIndex()
        {
            _betViewIndex++;

            if (_betViewIndex == _betViewCount)
                _betViewIndex = 0;
        }
    }
}
