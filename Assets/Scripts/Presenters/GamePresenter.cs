namespace Assets.Scripts.Presenters
{
    public class GamePresenter : IGamePresenter
    {
        public IGameView GameView { get; set; }

        public void SetGameView(IGameView gameView)
        {
            GameView = gameView;
        }
    }
}