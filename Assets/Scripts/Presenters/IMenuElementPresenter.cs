using Assets.Scripts.Prefabs;

namespace Assets.Scripts.Presenters
{
    public interface IMenuElementPresenter
    {
        void SetMenuElementView(IMenuElementView menuView);
        void OnClick(int index);
    }
}