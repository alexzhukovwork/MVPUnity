using Assets.Scripts.Prefabs;

namespace Assets.Scripts.Views
{
    public interface IMenuView
    {
        IMenuElementView[] MenuElementViews { get; set; }

        void SetMenuGames(IMenuElementView[] menuElementView);
        void SelectElement(int index);
    }
}