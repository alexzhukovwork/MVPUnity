
namespace Assets.Scripts.Models
{
    public interface IMenuElementModel
    {
        IGameView[] GameViews { get; set; }

        IGameView CurrentGameView { get; set; }

        void SelectCurrentGameView(int i);

        IGameView GetCurrent();
    }
}
