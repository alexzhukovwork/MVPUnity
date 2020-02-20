using Assets.Scripts.Additionals;
using Zenject;

namespace Assets.Scripts.Models.Games
{
    public abstract class Game : IGame
    {
        public abstract Games Id { get; }

        [Inject]
        private IContext Context { get; set; } 

        public void Select()
        {
            Context.Logger.Log(Id.ToString());
        }
    }
}
