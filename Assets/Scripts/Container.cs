using Assets.Scripts.Models;
using Assets.Scripts.Prefabs;
using Assets.Scripts.Presenters;
using Assets.Scripts.Views.Game;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Container : MonoInstaller
    {
        [SerializeField] private GameObject[] MenuPrefabs;

        [SerializeField] private GameObject[] GamePrefabs;

        public override void InstallBindings()
        {
            IGameView[] gameViews = new IGameView[GamePrefabs.Length];

            InitGameViews(gameViews);

            IMenuElementView[] menuPrefabs = new IMenuElementView[MenuPrefabs.Length];

            InitMenuElementViews(menuPrefabs);

            Container.Bind<IMenuModel>().To<MenuModel>().AsSingle().WithArguments(menuPrefabs);
            Container.Bind<IMenuElementModel>().To<MenuElementModel>().AsSingle().WithArguments(gameViews);
            Container.Bind<IMenuElementPresenter>().To<MenuElementPresenter>().AsSingle().Lazy();

            Container.Bind<IMenuPresenter>().To<MenuPresenter>().AsSingle();
            Container.Bind<IGamePresenter>().To<GamePresenter>().AsSingle();
        }

        private void InitMenuElementViews(IMenuElementView[] menuPrefabs)
        {
            for (int i = 0; i < MenuPrefabs.Length; i++)
            {
                GameObject gameObject = Container.InstantiatePrefab(MenuPrefabs[i]);

                menuPrefabs[i] = gameObject.GetComponent<IMenuElementView>();
            }
        }
        

        private void InitGameViews(IGameView[] gameViews)
        {
            for (int i = 0; i < gameViews.Length; i++)
            {
                GameObject gameObject = Container.InstantiatePrefab(GamePrefabs[i]);

                gameViews[i] = gameObject.GetComponent<IGameView>();
            }
        }
    }
}