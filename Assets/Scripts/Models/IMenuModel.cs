using Assets.Scripts.Prefabs;

namespace Assets.Scripts.Models
{
    public interface IMenuModel
    {
        IMenuElementView[] MenuPrefabs { get; }
        IMenuElementView Current { get; }
        void SetCurrentElement(int index);
    }
}