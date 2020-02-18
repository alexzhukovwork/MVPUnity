using Assets.Scripts.Views;

namespace Assets.Scripts.Presenters
{
    public interface IMenuPresenter
    {
        void SetMenuView(IMenuView menuView);
        void OnClick(int index);
    }
}