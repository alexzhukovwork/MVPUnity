using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Views.Game
{
    public abstract class GameView : MonoBehaviour, IGameView
    {
        public GameObject GameObject => gameObject;
    }
}