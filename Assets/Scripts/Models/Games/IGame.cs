using Assets.Scripts.Models.Games;
using Assets.Scripts.Presenters;

namespace Assets.Scripts.Models.Games
{
    public interface IGame
    {
        Games Id { get; }
        int BetViewIndex { get; }

        void Select();
        void SetPresenter(GamePresenter gamePresenter);
        void UpdateResults();
        void Unselect();

        void ChangeBetViewIndex();
    }
}