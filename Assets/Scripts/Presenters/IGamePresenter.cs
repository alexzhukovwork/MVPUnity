public interface IGamePresenter
{
    IGameView GameView { get; set; }

    void SetGameView(IGameView gameView);
}
