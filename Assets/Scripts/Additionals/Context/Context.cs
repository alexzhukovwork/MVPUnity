using Assets.Scripts.Additionals.Logger;
using Zenject;

namespace Assets.Scripts.Additionals
{
    public class Context : IContext
    {
        [Inject]
        public ILogger Logger { get; set; }
    }
}
