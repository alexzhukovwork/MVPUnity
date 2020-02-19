using Assets.Scripts.Models;
using Assets.Scripts.Prefabs;

namespace Assets.Scripts.Presenters
{
    public class MenuElementPresenter : IMenuElementPresenter
    {
        private IMenuElementModel MenuElementModel { get; set; }
       
        private IMenuElementView MenuElementView { get; set; }

        public void OnClick(int index)
        {
            MenuElementModel.SelectCurrentGameView(index);
        }

        public void SetMenuView(IMenuElementView menuView)
        {
            MenuElementView = menuView;
        }

        public MenuElementPresenter(IMenuElementModel menuElementModel)
        {
            MenuElementModel = menuElementModel;
        }
    }
}