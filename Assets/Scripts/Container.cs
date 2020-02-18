using Assets.Scripts.Models;
using Assets.Scripts.Prefabs;
using Assets.Scripts.Presenters;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Container : MonoInstaller
    {
        [SerializeField] private GameObject[] MenuPrefabs;

        public override void InstallBindings()
        {
            IMenuElementView[] menuPrefabs = new IMenuElementView[MenuPrefabs.Length];

            for (int i = 0; i < MenuPrefabs.Length; i++)
                menuPrefabs[i] = MenuPrefabs[i].GetComponent<IMenuElementView>();

            Container.Bind<IMenuModel>().To<MenuModel>().AsSingle().WithArguments<IMenuElementView[]>(menuPrefabs);
            Container.Bind<IMenuPresenter>().To<MenuPresenter>().AsSingle();
        }
    }
}