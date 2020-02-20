using System;
using System.Linq;
using Assets.Scripts.Additionals;
using Assets.Scripts.Models.Games;
using Assets.Scripts.Prefabs;
using Assets.Scripts.Presenters;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Container : MonoInstaller
    {
        [SerializeField] private GameObject[] GamePrefabs;

        public override void InstallBindings()
        {
            Container.Bind<Additionals.Logger.ILogger>().To<Additionals.Logger.Logger>().AsSingle();

            Container.Bind<IContext>().To<Additionals.Context>().AsSingle();

            Container.BindInstance(GetGames());

            Container.Bind<IGamePresenter>().To<GamePresenter>().AsSingle();

            IGameView[] gameViews = new IGameView[GamePrefabs.Length];

            InitGameViews(gameViews);
            
            Container.BindInstance(gameViews);

            IMenuElementView[] menuPrefabs = new IMenuElementView[GamePrefabs.Length];

            InitMenuElementViews(menuPrefabs);

            Container.BindInstance(menuPrefabs);

            Container.Bind<IMenuPresenter>().To<MenuPresenter>().AsSingle();
        }

        private void InitMenuElementViews(IMenuElementView[] menuPrefabs)
        {
            for (int i = 0; i < GamePrefabs.Length; i++)
            {
                GameObject gameObject = 
                    Container.InstantiatePrefab(GamePrefabs[i].GetComponentInChildren<IMenuElementView>().GameObject);

                menuPrefabs[i] = gameObject.GetComponent<IMenuElementView>();
            }
        }

        private void InitGameViews(IGameView[] gameViews)
        {
            for (int i = 0; i < gameViews.Length; i++)
            {
                GameObject gameObject = 
                    Container.InstantiatePrefab(GamePrefabs[i].GetComponentInChildren<IGameView>().GameObject, FindObjectOfType<Canvas>().transform);

                gameViews[i] = gameObject.GetComponent<IGameView>();
            }
        }

        private IGame[] GetGames()
        {
            Type[] types =  AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IGame).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToArray<Type>();

            IGame[] games = types.Select(x => (IGame)Activator.CreateInstance(x)).ToArray();

            return games;
        } 
    }
}