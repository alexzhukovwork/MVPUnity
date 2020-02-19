using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Views.Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        public GameObject GameObject => gameObject;
    
        public IGamePresenter GamePresenter { get; set; }
    }
}