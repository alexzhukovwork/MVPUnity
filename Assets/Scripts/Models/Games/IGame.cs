using Assets.Scripts.Models.Games;

namespace Assets.Scripts.Models.Games
{
    public interface IGame
    {
        Games Id { get; }

        void Select();
    }
}