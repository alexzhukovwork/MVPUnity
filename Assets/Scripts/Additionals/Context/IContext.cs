using Assets.Scripts.Additionals.Logger;

namespace Assets.Scripts.Additionals
{
    public interface IContext
    {
        ILogger Logger { get; set; }
    }
}
