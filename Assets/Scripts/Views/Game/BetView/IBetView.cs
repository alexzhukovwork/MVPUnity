namespace Assets.Scripts.Views.Game.BetView
{
    public interface IBetView
    {
        void Clear();
        void Activate();
        string BetName { get; }
    }
}