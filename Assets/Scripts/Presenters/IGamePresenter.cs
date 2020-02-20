public interface IGamePresenter
{
    IGameView GameView { get; set; }

    void SelectGame(IGameView gameView);
}
