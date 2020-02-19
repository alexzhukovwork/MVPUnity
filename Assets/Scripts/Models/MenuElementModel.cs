using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class MenuElementModel : IMenuElementModel
    {
        public IGameView[] GameViews { get; set; }
        public IGameView CurrentGameView { get; set; }

        public MenuElementModel(IGameView[] gameViews)
        {
            GameViews = gameViews;
        }

        public IGameView GetCurrent()
        {
            return CurrentGameView;
        }

        public void SelectCurrentGameView(int i)
        {
            if (GameViews.Length > 0)
                CurrentGameView = GameViews[i];
        }
    }
}
