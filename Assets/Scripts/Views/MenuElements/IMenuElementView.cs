
using System;
using UnityEngine;
using static UnityEngine.UI.Button;

namespace Assets.Scripts.Prefabs
{
    public interface IMenuElementView
    {
        GameObject IGameView { get; }
        GameObject GameObject { get; }
        Action OnClick { get; set; }
        void Select();
        void Unselect();
    }
}