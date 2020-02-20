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
            Container.Bind<IGamePresenter>().To<GamePresenter>().AsSingle();

            IGameView[] gameViews = new IGameView[GamePrefabs.Length];

            InitGameViews(gameViews);
            
            Container.Bind<IMenuElementModel>().To<MenuElementModel>().AsSingle();
            Container.BindInstance(gameViews);
            Container.Bind<IMenuElementPresenter>().To<MenuElementPresenter>().AsSingle();

            IMenuElementView[] menuPrefabs = new IMenuElementView[MenuPrefabs.Length];

            InitMenuElementViews(menuPrefabs);

            Container.Bind<IMenuModel>().To<MenuModel>().AsSingle();
            Container.BindInstance(menuPrefabs);

            Container.Bind<IMenuPresenter>().To<MenuPresenter>().AsSingle();
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
                GameObject gameObject = Container.InstantiatePrefab(GamePrefabs[i], FindObjectOfType<Canvas>().transform);

                gameViews[i] = gameObject.GetComponent<IGameView>();
            }
        }
    }
}