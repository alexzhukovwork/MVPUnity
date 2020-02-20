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

        }

        public void SetMenuElementView(IMenuElementView menuElementView)
        {
            MenuElementView = menuElementView;
        }


        public MenuElementPresenter(IMenuElementModel menuElementModel)
        {
            MenuElementModel = menuElementModel;
        }
    }
}